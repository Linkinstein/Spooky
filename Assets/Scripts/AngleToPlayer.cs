using System;
using UnityEngine;

public class AngleToPlayer : MonoBehaviour
{
    private Transform pt;
    private Vector3 targetPos;
    private Vector3 targetDir;

    private SpriteRenderer sr;

    private float angle;
    public int lastIndex;

    void Start()
    {
        pt = GameObject.FindWithTag("Player").GetComponent<Transform>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        targetPos = new Vector3(pt.position.x, transform.position.y, pt.position.z);
        targetDir = targetPos - transform.position;

        angle = Vector3.SignedAngle(targetDir, transform.forward, Vector3.up);

        Vector3 tempScale = Vector3.one;
        if (angle > 0) { tempScale.x *= -1f; }
        sr.transform.localScale = tempScale;

        lastIndex = GetIndex(angle);
    }


    private int GetIndex(float angle)
    {
        //front
        if (angle > -22.5f && angle < 22.6f)
            return 0;
        if (angle >= 22.5f && angle < 67.5f)
            return 7;
        if (angle >= 67.5f && angle < 112.5f)
            return 6;
        if (angle >= 112.5f && angle < 157.5f)
            return 5;


        //back
        if (angle <= -157.5 || angle >= 157.5f)
            return 4;
        if (angle >= -157.4f && angle < -112.5f)
            return 3;
        if (angle >= -112.5f && angle < -67.5f)
            return 2;
        if (angle >= -67.5f && angle <= -22.5f)
            return 1;

        return lastIndex;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward);
    }
}