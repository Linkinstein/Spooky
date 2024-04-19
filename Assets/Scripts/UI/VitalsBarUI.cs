using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VitalsBarUI : MonoBehaviour
{
    private CharacterVitals cv;
    private Image img;
    [SerializeField] private bool mp;

    void Start()
    {
        if (GameObject.FindWithTag("Player") != null) cv = GameObject.FindWithTag("Player").GetComponent<CharacterVitals>();
        img = GetComponent<Image>();
    }

    void Update()
    {
        if (cv != null)
        {
            float t = 0f;
            if (mp)  t = cv.mp/100f;
            else t = cv.hp/100f;
            Debug.Log(t);
            img.fillAmount = t;
        }

    }
}
