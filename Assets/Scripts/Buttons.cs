using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private Button button;

    [SerializeField] private bool exit;

    private void OnEnable()
    {
        button = GetComponent<Button>();
        if (exit) button.onClick.AddListener(() => Exit());
    }

    public void Exit()
    {
        Application.Quit();
    }
}
