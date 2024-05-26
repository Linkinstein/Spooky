using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] private bool startEllie;
    [SerializeField] private bool patEllie;
    [SerializeField] private bool projector;
    [SerializeField] private GameObject video;

    private UIManager ui
    { get { return UIManager.Instance; } }

    private GameManager gm
    { get { return GameManager.Instance; } }

    public string iName
    { get { return item.itemName; } }

    public string iVerb
    { 
        get 
        {
            if (door||projector) return "Requires";
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

        if (startEllie)
        {
            SceneManager.LoadScene(2);
        }

        if (patEllie)
        {
            SceneManager.LoadScene(3);
        }

        if (projector)
        {
            foreach (ItemData id in gm.keyItems)
            {
                if (id.itemName.Equals(item.itemName))
                {
                    if (video != null) 
                    { 
                        video.SetActive(true); 
                        this.gameObject.GetComponent<BoxCollider>().enabled = false;
                    }
                }
            }
        }
    }

    private void Progress()
    {
        if (gm != null)
        {
            if (gm.objectivesIndex<progressIndex) gm.objectivesIndex = progressIndex;
        }

        if (ui != null)
        {
            ui.updateObj();
        }
    }
}
