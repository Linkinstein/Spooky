using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimer : MonoBehaviour
{
    [SerializeField] private float lifetime = 1f;

    void Start()
    {
        StartCoroutine(lifetick());
    }

    private IEnumerator lifetick()
    {
        yield return new WaitForSeconds(lifetime); 
        GameObject.Destroy(this.gameObject);
    }
}
