using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    private CharacterVitals cv;
    [SerializeField] private GameObject leftHand;
    [SerializeField] private GameObject rightHand;
    private Hands lHand;
    private Hands rHand;

    [SerializeField] private GameObject[] spells;

    private bool paused
    { get { return GameManager.Instance.paused; } }

    void Start()
    {
        if (GameObject.FindWithTag("Player") != null) cv = GameObject.FindWithTag("Player").GetComponent<CharacterVitals>();
        lHand = leftHand.GetComponent<Hands>();
        rHand = rightHand.GetComponent<Hands>();
    }

    void Update()
    {
        if (!paused)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                executeSpell();
            }
        }
    }

    private void executeSpell()
    {
        Vector2 handSigns = new Vector2(lHand.handIndex, rHand.handIndex);
        if (handSigns == new Vector2(1, 1))
        {
            Debug.Log("1 1");
        }
        else if (handSigns == new Vector2(1, 2))
        {
            Debug.Log("1 2");
        }
        else if (handSigns == new Vector2(1, 3) && cv.mp >= 60)
        {
            Vector3 spawnPosition = transform.position + transform.forward;
            GameObject instanceObj = Instantiate(spells[3], spawnPosition, Quaternion.identity);
            instanceObj.transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            ExpendMana(60);
        }
        else if (handSigns == new Vector2(2, 1))
        {
            Debug.Log("2 1");
        }
        else if (handSigns == new Vector2(2, 2))
        {
            Debug.Log("2 2");
        }
        else if (handSigns == new Vector2(2, 3))
        {
            Debug.Log("2 3");
        }
        else if (handSigns == new Vector2(3, 1) && cv.mp >= 10)
        {
            GameObject instanceObj = Instantiate(spells[0], transform.position, Quaternion.identity);
            instanceObj.transform.rotation = transform.rotation;
            ExpendMana(10);
        }
        else if (handSigns == new Vector2(3, 2) && cv.mp >= 25)
        {
            Vector3 spawnPosition = transform.position + new Vector3(0, -1.2f, 0);
            GameObject instanceObj = Instantiate(spells[1], spawnPosition, Quaternion.identity);
            instanceObj.transform.Rotate(new Vector3(90, 0, 0), Space.World);
            ExpendMana(25);
        }
        else if (handSigns == new Vector2(3, 3) && cv.mp >= 40)
        { 
            Vector3 spawnPosition = transform.position + transform.forward;
            GameObject instanceObj = Instantiate(spells[2], spawnPosition, Quaternion.identity);
            instanceObj.transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            ExpendMana(40);
        }
        lHand.ResetHand();
        rHand.ResetHand();
    }

    private void ExpendMana(int i)
    {
        if (cv != null)
        {
            cv.UseMP(i);
        }
    }
}
