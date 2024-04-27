using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemData", menuName = "ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] public Sprite itemImage;

    [SerializeField] public string itemName;

    [SerializeField] public string itemDescription;

    [SerializeField] public string verb;
}
