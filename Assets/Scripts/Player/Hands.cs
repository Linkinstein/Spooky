using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hands : MonoBehaviour
{
    private GameManager gm;
    [SerializeField] private bool left = false;

    private SpriteRenderer sr;

    [SerializeField] private Sprite[] handsigns;

    public int handIndex = 0;

    private bool paused
    { 
        get 
        { 
            if (gm != null)
                return gm.paused; 
            else return false;
        }
    }

    private void Start()
    {
        if (GameObject.FindWithTag("GameManager") != null) gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!paused)
        {
            if (Input.GetMouseButtonDown(0) && left || Input.GetMouseButtonDown(1) && !left)
            {
                handIndex++;
                if (handIndex == 4) handIndex = 1;

                sr.sprite = handsigns[handIndex];

            }
        }
    }

    public void ResetHand()
    {
        handIndex = 0;
        sr.sprite = handsigns[handIndex];
    }
}
