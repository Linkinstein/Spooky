using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Animator spriteAnim;
    private AngleToPlayer atp;

    private void Start()
    {
        spriteAnim = GetComponentInChildren<Animator>();
        atp = GetComponent<AngleToPlayer>();

    }

    void Update()
    {
        spriteAnim.SetFloat("spriteRot", atp.lastIndex);


    }

}
