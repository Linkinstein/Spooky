using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUseButton : MonoBehaviour
{
    [SerializeField] private ItemData emptyItem;

    public string itemName;
    private Button button;

    private CharacterVitals cv
    { get { return CharacterVitals.Instance; } }

    private GameManager gm
    { get { return GameManager.Instance; } }

    private UIManager ui
    { get { return UIManager.Instance; } }

    private void OnEnable()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(use);
    }

    private void use()
    {
        if (itemName != null) 
        {
            if (itemName.Equals("Small Health Potion"))
            { 
                if((cv.hp + 25) > 100) cv.hp = 100; 
                else cv.hp += 25;
            }


            for (int i = gm.consumables.Count - 1; i >= 0; i--)
            {
                if (gm.consumables[i].itemName == itemName)
                {
                    gm.consumables.RemoveAt(i);
                }
            }

            ui.displayConsumable(emptyItem);
            itemName = null;
        }
    }
}
