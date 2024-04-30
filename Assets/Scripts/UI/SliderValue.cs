using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SliderValue : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField] private bool mSensitivity;

    private void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeText(float i)
    {
        if (mSensitivity) text.SetText((i/10f)+"");
        else text.SetText(i+"");
    }
}
