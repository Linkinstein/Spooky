using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellProjectile : MonoBehaviour
{
    [SerializeField] public float speed = 10f;
    [SerializeField] private bool fragile = false;
    private Vector3 direction;

    private void Start()
    {
        direction = transform.forward;
    }

    void Update()
    {
        GetComponent<Rigidbody>().velocity = direction * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && fragile) Destroy(this.gameObject);
    }
}
