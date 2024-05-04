using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVitals : MonoBehaviour
{
    public static CharacterVitals Instance { get; private set; }

    public int hp = 100;
    public int mp = 100;

    public float mpCD = 0;


    private bool recharging = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (mpCD > 0) mpCD -= Time.deltaTime;

        if (mp < 100 && !recharging && mpCD <= 0)
        {
            recharging = true;
            StartCoroutine(restoreMP());
        }

        if (hp <= 0 && !GameManager.Instance.cinematic) UIManager.Instance.Death();
    }

    public void UseMP(int i)
    {
        mpCD = 3;
        mp -= i;
    }

    IEnumerator restoreMP() 
    { 
        if ((mp + 5) > 100) mp = 100;
        else mp += 5;
        yield return new WaitForSeconds(1f);
        recharging = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Damage")
        { 
            hp -= 25;
        }
    }
}
