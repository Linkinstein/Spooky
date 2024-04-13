using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    private int waypointIndex = 0;
    private NavMeshAgent agent;
    private Vector3 target;

    private Animator spriteAnim;
    private AngleToPlayer atp;

    private Boolean chasing = false;
    private Boolean waiting = false;


    private void Start()
    {
        spriteAnim = GetComponentInChildren<Animator>();
        atp = GetComponent<AngleToPlayer>();
        agent = GetComponent<NavMeshAgent>();
        if (waypoints.Length != 0) UpdateDestination();
    }

    private void Update()
    {
        spriteAnim.SetFloat("spriteRot", atp.lastIndex);
        if (target != null && Vector3.Distance(transform.position, target) < 1 && !waiting)
        {
            StartCoroutine(patrolWait());
        }

    }
    private void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }
    private void IteratewaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    private IEnumerator patrolWait()
    {
        waiting = true;
        yield return new WaitForSeconds(3f);
        if (!chasing)
        {
            IteratewaypointIndex();
            UpdateDestination();
            waiting = false;
        }
    }
}
