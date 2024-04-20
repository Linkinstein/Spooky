using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteShadow : MonoBehaviour
{
    private Transform pt;
    private SpriteRenderer sr; 
    private Color dark = Color.black; 
    private Color bright = Color.white;
    [SerializeField] private float maxDistance = 10f; 

    void Start()
    {
        pt = GameObject.FindWithTag("Player").GetComponent<Transform>(); 
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, pt.position);
        float distanceRatio = Mathf.Clamp01(distance / maxDistance);
        Color targetColor = Color.Lerp(dark, bright, 1 - distanceRatio);
        sr.color = targetColor;
    }
}
