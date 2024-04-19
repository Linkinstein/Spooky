using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager gm;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject[] tabs;

    [SerializeField] GameObject[] spellTabGOs;

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
            // 0 Diary
            if (Input.GetKeyDown(KeyCode.Z)) toggleMenu(paused, 0);
            // 1 Map
            if (Input.GetKeyDown(KeyCode.Tab)|| Input.GetKeyDown(KeyCode.M)) toggleMenu(paused, 1);
            // 2 Notes
            if (Input.GetKeyDown(KeyCode.X)) toggleMenu(paused, 2);
            // 3 Spells
            if (Input.GetKeyDown(KeyCode.C)) toggleMenu(paused, 3);
            // 4 Inventory
            if (Input.GetKeyDown(KeyCode.I)|| Input.GetKeyDown(KeyCode.B)) toggleMenu(paused, 4);
            // 5 Key Items
            if (Input.GetKeyDown(KeyCode.V)) toggleMenu(paused, 5);
        }
    }

    public void toggleMenu(bool on, int i)
    {
        if (!on)
        {
            paused = true;
            pauseUI.SetActive(true);
            jumpToTab(i);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            if (!tabs[i].activeSelf) jumpToTab(i);
            else
            {
                paused = false;
                pauseUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    public void jumpToTab(int i)
    {
        foreach (GameObject tab in tabs) tab.SetActive(false);
        tabs[i].SetActive(true);
    }

    public void displaySpell(SpellData sd)
    {
        jumpToTab(3);
        spellTabGOs[0].GetComponent<Image>().sprite = sd.hand1;
        spellTabGOs[1].GetComponent<Image>().sprite = sd.hand2;
        spellTabGOs[2].GetComponent<TextMeshProUGUI>().SetText(sd.spellName);
        string description = sd.spellDescription;
        description = description.Replace("\\n", "\n");
        spellTabGOs[3].GetComponent<TextMeshProUGUI>().SetText(description);
    }
}
