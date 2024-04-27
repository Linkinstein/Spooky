using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject[] tabs;

    [SerializeField] private GameObject[] spellTabGOs;
    [SerializeField] private GameObject[] keyTabGOs;
    [SerializeField] private GameObject[] consumTabGOs;

    private bool paused
    { 
        get { return GameManager.Instance.paused; }
        set { GameManager.Instance.paused = value; }
    }

    private bool cinematic
    {
        get { return GameManager.Instance.cinematic; }
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
    }

    private void Update()
    {
        if (!cinematic)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (!paused) toggleMenu(paused,1);
                else toggleMenu(paused);
            }

            // 0 Diary
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Escape)) toggleMenu(paused, 0);
            // 1 Map
            if (Input.GetKeyDown(KeyCode.M)) toggleMenu(paused, 1);
            // 2 Notes
            if (Input.GetKeyDown(KeyCode.X)) toggleMenu(paused, 2);
            // 3 Spells
            if (Input.GetKeyDown(KeyCode.C)) toggleMenu(paused, 3);
            // 4 Inventory
            if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.B)) toggleMenu(paused, 4);
            // 5 Key Items
            if (Input.GetKeyDown(KeyCode.V)) toggleMenu(paused, 5);
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

    public void displayConsumable(ItemData id)
    {
    }
}
