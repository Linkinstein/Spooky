using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Image imgUi;
    [SerializeField] public bool key;

    private ItemData _id;

    private Button button;

    public ItemData id
    {
        set 
        { 
            _id = value;
            text.SetText(value.itemName);
            imgUi.sprite = value.itemImage;
            button.onClick.AddListener(displayItem);
        }
    }

    private void OnEnable()
    {
        button = GetComponent<Button>();
    }

    private void displayItem()
    {
        if (key) UIManager.Instance.displayKey(_id);
        else UIManager.Instance.displayConsumable(_id);
    }
}
