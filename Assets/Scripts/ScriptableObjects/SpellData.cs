using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New SpellData", menuName = "SpellData")]
public class SpellData : ScriptableObject
{
    [SerializeField] public Sprite hand1;

    [SerializeField] public Sprite hand2;

    [SerializeField] public string spellName;

    [TextArea(10, 30)]
    [SerializeField] public string spellDescription;
}
