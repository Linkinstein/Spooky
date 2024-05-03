using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] public ItemData item;

    [SerializeField] private bool keyItem;
    [SerializeField] private bool door;
    [SerializeField] private bool consumable;

    public string iName
    { get { return item.itemName; } }

    public string iVerb
    { 
        get 
        {
            if (door) return "Requires";
            else return item.verb;
        } 
    }


    public void interact()
    {

        if (keyItem) 
        {
            GameManager.Instance.keyItems.Add(item);
            Destroy(gameObject);
        }

        if (door) 
        {
            foreach (ItemData id in GameManager.Instance.keyItems)
            {
                if (id.itemName.Equals(item.itemName))
                {
                    Destroy(gameObject);
                }
            }
        }

        if (consumable)
        {
            GameManager.Instance.consumables.Add(item);
            Destroy(gameObject);
        }
    }
}
