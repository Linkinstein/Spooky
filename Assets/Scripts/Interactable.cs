using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] public ItemData item;

    [SerializeField] private bool willProgress;
    [Space]
    [SerializeField] private bool keyItem;
    [SerializeField] private bool door;
    [SerializeField] private bool consumable;
    [SerializeField] private bool note;

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

        if (door) 
        {
            foreach (ItemData id in GameManager.Instance.keyItems)
            {
                if (id.itemName.Equals(item.itemName))
                {
                    if (willProgress) Progress();
                    Destroy(gameObject);
                }
            }
        }

        if (keyItem || consumable || note)
        {
            if (keyItem) GameManager.Instance.keyItems.Add(item);
            if (consumable) GameManager.Instance.consumables.Add(item);
            if (note) GameManager.Instance.notes.Add(item);

            if (willProgress) Progress();
            Destroy(gameObject);
        }

    }

    private void Progress()
    {
        if (GameManager.Instance != null) GameManager.Instance.objectivesIndex++;
        
    }
}
