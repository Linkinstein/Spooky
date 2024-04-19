using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager gm;
    [SerializeField] GameObject pauseUI;

    private bool paused
    { 
        get 
        { 
            if (gm != null)
                return gm.paused; 
            else return false;
        }
        set { if (gm != null) gm.paused = value; }
    }

    private bool cinematic
    {
        get
        {
            if (gm != null)
                return gm.cinematic;
            else return false;
        }
    }

    private void Start()
    {
        if (GameObject.FindWithTag("GameManager") != null) gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (!cinematic)
        {
            if (Input.GetKeyDown(KeyCode.Tab)) toggleMenu(paused);
        }
    }

    public void toggleMenu(bool on)
    {
        if (on)
        {
            paused = false;
            pauseUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            paused = true;
            pauseUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
