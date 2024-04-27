using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemButtonMaker : MonoBehaviour
{
    [SerializeField] private GameObject itemButtonPrefab;

    [SerializeField] private bool key;

    void OnEnable()
    {
        for (var i = this.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }

        if (key)
        {
            foreach (ItemData item in GameManager.Instance.keyItems)
            {
                GameObject prefab = Instantiate(itemButtonPrefab, transform.position, Quaternion.identity);
                prefab.transform.SetParent(this.gameObject.transform, false);
                ItemButton ib = prefab.GetComponent<ItemButton>();
                ib.id = item;
                ib.key = key;
            }
        }
        else
        {
            foreach (ItemData item in GameManager.Instance.consumables)
            {
                GameObject prefab = Instantiate(itemButtonPrefab, transform.position, Quaternion.identity);
                prefab.transform.SetParent(this.gameObject.transform, false);
                ItemButton ib = prefab.GetComponent<ItemButton>();
                ib.id = item;
                ib.key = key;
            }
        }

    }

    
}
