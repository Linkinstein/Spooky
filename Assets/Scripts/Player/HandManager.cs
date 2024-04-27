using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    private GameManager gm;
    private CharacterVitals cv;
    [SerializeField] private GameObject leftHand;
    [SerializeField] private GameObject rightHand;
    private Hands lHand;
    private Hands rHand;

    [SerializeField] private GameObject lightOrb;
    [SerializeField] private GameObject lightSigil;

    private bool paused
    {
        get
        {
            if (gm != null)
                return gm.paused;
            else return false;
        }
    }

    void Start()
    {
        if (GameObject.FindWithTag("GameManager") != null) gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
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
        else if (handSigns == new Vector2(1, 3))
        {
            Debug.Log("1 3");
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
            //Vector3 spawnPosition = transform.position + transform.forward;
            GameObject instanceObj = Instantiate(lightOrb, transform.position, Quaternion.identity);
            instanceObj.transform.rotation = transform.rotation;
            ExpendMana(10);
        }
        else if (handSigns == new Vector2(3, 2) && cv.mp >= 25)
        {
            Vector3 spawnPosition = transform.position + new Vector3(0, -1.2f, 0);
            GameObject instanceObj = Instantiate(lightSigil, spawnPosition, Quaternion.identity);
            instanceObj.transform.Rotate(new Vector3(90, 0, 0), Space.World);
            ExpendMana(25);
        }
        else if (handSigns == new Vector2(3, 3))
        {
            Debug.Log("3 3");
        }
        lHand.ResetHand();
        rHand.ResetHand();
    }

    private void ExpendMana(int i)
    {
        if (cv != null)
        {
            cv.mp -= i;
        }
    }
}
