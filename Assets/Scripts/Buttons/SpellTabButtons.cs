using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellTabButtons : MonoBehaviour
{
    private GameManager gm;
    private Button button;

    [SerializeField] private GameObject UIGO;
    private UIManager ui;

    [SerializeField] private int index;
    [SerializeField] private SpellData sd;

    private bool[] spellsUnlocked
    {
        get
        {
            if (gm != null)
                return gm.spellsUnlocked;
            else return null;
        }
    }

    private void OnEnable()
    {
        ui = UIGO.GetComponent<UIManager>();
        if (GameObject.FindWithTag("GameManager") != null) gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        button = GetComponent<Button>();

        if (spellsUnlocked != null)
        { 
            if (!spellsUnlocked[index]) gameObject.SetActive(false);
        }

        button.onClick.AddListener(displaySpell);
    }

    private void displaySpell()
    {
        ui.displaySpell(sd);
    }

}
