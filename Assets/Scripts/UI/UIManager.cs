using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject objUpdater;

    [SerializeField] private GameObject screenUI;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject deathUI;
    [SerializeField] private GameObject[] tabs;

    [SerializeField] private GameObject[] spellTabGOs;
    [SerializeField] private GameObject[] keyTabGOs;
    [SerializeField] private GameObject[] noteTabGOs;
    [SerializeField] private GameObject[] consumTabGOs;

    private GameManager gm
    { get { return GameManager.Instance; } }

    private bool paused
    { 
        get { return gm.paused; }
        set { gm.paused = value; }
    }

    private bool cinematic
    {
        get { return gm.cinematic; }
        set { gm.cinematic = value; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (gm != null)
        { 
            gm.paused = false;
            gm.cinematic = false;
        }
    }

    private void Update()
    {
        if (!cinematic)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (!paused) toggleMenu(paused,0);
                else toggleMenu(paused);
            }

            // 0 Diary
            if (Input.GetKeyDown(KeyCode.Z)) toggleMenu(paused, 0);
            // 1 Map
            //if (Input.GetKeyDown(KeyCode.M)) toggleMenu(paused, 1);
            // 2 Notes
            if (Input.GetKeyDown(KeyCode.X)) toggleMenu(paused, 2);
            // 3 Spells
            if (Input.GetKeyDown(KeyCode.C)) toggleMenu(paused, 3);
            // 4 Inventory
            if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.B)) toggleMenu(paused, 4);
            // 5 Key Items
            if (Input.GetKeyDown(KeyCode.V)) toggleMenu(paused, 5);
            // 6 Settings
            if (Input.GetKeyDown(KeyCode.Escape)) toggleMenu(paused, 6);
        }
    }

    public void toggleMenu(bool on)
    {
        if (!on)
        {
            paused = true;
            pauseUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            paused = false;
            pauseUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
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

    public void displayKey(ItemData id)
    {
        jumpToTab(5);
        keyTabGOs[0].GetComponent<Image>().sprite = id.itemImage;
        keyTabGOs[1].GetComponent<TextMeshProUGUI>().SetText(id.itemName);
        string description = id.itemDescription;
        description = description.Replace("\\n", "\n");
        keyTabGOs[2].GetComponent<TextMeshProUGUI>().SetText(description);
    }

    public void displayNote(ItemData id)
    {
        jumpToTab(2);
        noteTabGOs[0].GetComponent<TextMeshProUGUI>().SetText(id.itemName);
        string description = id.itemDescription;
        description = description.Replace("\\n", "\n");
        noteTabGOs[1].GetComponent<TextMeshProUGUI>().SetText(description);
    }

    public void displayConsumable(ItemData id)
    {
        jumpToTab(4);
        consumTabGOs[0].GetComponent<Image>().sprite = id.itemImage;
        consumTabGOs[1].GetComponent<TextMeshProUGUI>().SetText(id.itemName);
        string description = id.itemDescription;
        description = description.Replace("\\n", "\n");
        consumTabGOs[2].GetComponent<TextMeshProUGUI>().SetText(description);
        consumTabGOs[3].GetComponent<ItemUseButton>().itemName = id.itemName;
    }

    public void Death()
    { 
        screenUI.SetActive(false);
        pauseUI.SetActive(false);
        deathUI.SetActive(true);
        paused = true;
        cinematic = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void updateObj()
    {
        objUpdater.SetActive(false);
        objUpdater.SetActive(true);
    }
}
