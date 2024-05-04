using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool paused = false;
    public bool cinematic = false;

    public bool[] spellsUnlocked = { false, false, true, false, false, false, true, true, true };

    [SerializeField] public string[] objectives;
    public int objectivesIndex = 0;

    public List<ItemData> keyItems = new List<ItemData>();
    public List<ItemData> consumables = new List<ItemData>();
    public List<ItemData> notes = new List<ItemData>();

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

    public void StartNew()
    {
        paused = false;
        cinematic = false;
        objectivesIndex = 0;
        keyItems = new List<ItemData>();
        consumables = new List<ItemData>();
        notes = new List<ItemData>();
        keyItems.Add(amulet);
        SceneManager.LoadScene(1);
    }
}
