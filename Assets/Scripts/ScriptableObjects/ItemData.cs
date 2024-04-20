using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemData", menuName = "ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] public Sprite ItemImage;

    [SerializeField] public string ItemName;

    [SerializeField] public string ItemDescription;

    [SerializeField] public string Verb;
}
