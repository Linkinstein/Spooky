using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickerer : MonoBehaviour
{
    private Light l;

    [SerializeField] private float[] ontime;
    [SerializeField] private float[] offtime;
    private int i = 0;

    void Start()
    {
        l = GetComponent<Light>();
        if (ontime.Length != 0 && offtime.Length != 0) StartCoroutine(flicker());
    }

    IEnumerator flicker()
    {
        if (i >= ontime.Length || i >= offtime.Length) i = 0;
        l.enabled = true;
        yield return new WaitForSeconds(ontime[i]);
        l.enabled = false;
        yield return new WaitForSeconds(offtime[i]);
        l.enabled = true;
        i++;
        StartCoroutine(flicker());
    }
}
