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
            if (itemName.Equals("Red Vial"))
            { 
                if((cv.hp + 25) > 100) cv.hp = 100; 
                else cv.hp += 25;
            }

            if (itemName.Equals("Red Bottle"))
            {
                cv.hp = 100;
            }

            if (itemName.Equals("Blue Vial"))
            {
                if ((cv.mp + 50) > 100) cv.mp = 100;
                else cv.mp += 50;
            }

            if (itemName.Equals("Blue Bottle"))
            {
                cv.mp = 100;
            }


            for (int i = gm.consumables.Count - 1; i >= 0; i--)
            {
                if (gm.consumables[i].itemName == itemName)
                {
                    gm.consumables.RemoveAt(i);
                    break;
                }
            }

            ui.displayConsumable(emptyItem);
            itemName = null;
        }
    }
}
