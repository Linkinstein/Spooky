using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] public ItemData item;

    [SerializeField] private bool keyItem;
    [SerializeField] private bool door;
    [SerializeField] private bool consumable;

    [SerializeField] private ItemData key4Door;

    public void interact()
    {

        if (keyItem) 
        {
            GameManager.Instance.keyItems.Add(item);
            Destroy(gameObject);
        }

        if (door) 
        {
            
        }

        if (consumable)
        {
            GameManager.Instance.consumables.Add(item);
            Destroy(gameObject);
        }
    }
}
