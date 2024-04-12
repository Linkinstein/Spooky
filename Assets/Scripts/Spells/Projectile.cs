using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] public float speed = 10f;
    public Vector3 direction;

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
        if (collision != null) Destroy(this.gameObject);
    }
}
