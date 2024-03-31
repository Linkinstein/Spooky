using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hands : MonoBehaviour
{
    [SerializeField] private bool left = false;

    private SpriteRenderer sr;

    [SerializeField] private Sprite[] handsigns;

    public int handIndex = 0;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && left || Input.GetMouseButtonDown(1) && !left)
        {
            handIndex++;
            if (handIndex == 4) handIndex = 1;

            sr.sprite = handsigns[handIndex];

        }
    }

    public void ResetHand()
    {
        handIndex = 0;
        sr.sprite = handsigns[handIndex];
    }
}
