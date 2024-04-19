using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookButtons : MonoBehaviour
{
    [SerializeField] private GameObject UIGO;
    private UIManager ui;
    private Button button;

    [SerializeField] private int index;

    private void OnEnable()
    {
        ui = UIGO.GetComponent<UIManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(displayTab);
    }

    private void displayTab()
    {
        ui.jumpToTab(index);
    }
}
