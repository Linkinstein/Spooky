using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [SerializeField] GameObject leftHand;
    [SerializeField] GameObject rightHand;
    private Hands lHand;
    private Hands rHand;


    void Start()
    {
        lHand = leftHand.GetComponent<Hands>();
        rHand = rightHand.GetComponent<Hands>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            executeSpell();
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
        else if (handSigns == new Vector2(3, 1))
        {
            Debug.Log("3 1");
        }
        else if (handSigns == new Vector2(3, 2))
        {
            Debug.Log("3 2");
        }
        else if (handSigns == new Vector2(3, 3))
        {
            Debug.Log("3 3");
        }
        lHand.ResetHand();
        rHand.ResetHand();
    }
}
