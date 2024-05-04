using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] public ItemData item;
    [Space]
    [SerializeField] private bool willProgress;
    [SerializeField] private int progressIndex = 0;
    [Space]
    [SerializeField] private bool keyItem;
    [SerializeField] private bool door;
    [SerializeField] private bool consumable;
    [SerializeField] private bool note;

    private GameManager gm
    { get { return GameManager.Instance; } }

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
            foreach (ItemData id in gm.keyItems)
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
            if (keyItem) gm.keyItems.Add(item);
            if (consumable) gm.consumables.Add(item);
            if (note) gm.notes.Add(item);

            if (willProgress) Progress();
            Destroy(gameObject);
        }

    }

    private void Progress()
    {
        if (gm != null)
        {
            if (gm.objectivesIndex<progressIndex) gm.objectivesIndex = progressIndex;
        } 
        
    }
}
