using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GenericButton : MonoBehaviour
{
    private Button button;

    [SerializeField] private bool exit;
    [SerializeField] private bool start;
    [SerializeField] private bool back2menu;

    private void OnEnable()
    {
        button = GetComponent<Button>();
        if (exit) button.onClick.AddListener(() => Exit());
        if (start) button.onClick.AddListener(() => Play());
        if (back2menu) button.onClick.AddListener(() => Back2Menu());
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Play()
    {
        if (GameManager.Instance != null) GameManager.Instance.StartNew();
        else SceneManager.LoadScene(1);
    }

    public void Back2Menu()
    {
        SceneManager.LoadScene(0);
    }
}
