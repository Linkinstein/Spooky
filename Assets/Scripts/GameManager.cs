using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool paused = false;
    public bool cinematic = false;

    public bool[] spellsUnlocked = { false, false, false, false, false, false, true, true, false};

    public List<ItemData> keyItems = new List<ItemData>();
    public List<ItemData> consumables = new List<ItemData>();

    //delete later
    [SerializeField] private ItemData amulet;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            keyItems.Add(amulet);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
