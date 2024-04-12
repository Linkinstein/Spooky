using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotator : MonoBehaviour
{
    private Transform pt;
    [SerializeField] private bool lookVertically;

    void Start()
    {
        pt = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
    }

    void Update()
    {
        if (lookVertically)
        {
            transform.LookAt(pt);
        }
        else
        { 
            Vector3 moddedpt = pt.position;
            moddedpt.y = transform.position.y;

            transform.LookAt(moddedpt);
        }
    }
}
