using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVitals : MonoBehaviour
{
    public int hp = 100;
    public int mp = 100;

    private bool recharging = false;

    private void Update()
    {
        if (mp < 100 && !recharging)
        {
            recharging = true;
            StartCoroutine(restoreMP());
        }
    }

    IEnumerator restoreMP() 
    { 
        yield return new WaitForSeconds(1f);
        if ((mp + 5) > 100) mp = 100;
        else mp += 5;
        recharging = false;
    }
}
