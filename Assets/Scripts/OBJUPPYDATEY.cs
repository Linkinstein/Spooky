using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJUPPYDATEY : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(uppitydatey());
    }

    private IEnumerator uppitydatey()
    { 
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
    }
}
