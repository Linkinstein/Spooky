using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    private FieldOfView fov;
    [SerializeField] private Transform[] waypoints;
    private int waypointIndex = 0;
    private NavMeshAgent agent;
    private Vector3 target;

    private Animator spriteAnim;
    private AngleToPlayer atp;
    private bool waiting = false;

    private bool attacking = false;
    [SerializeField] GameObject atkCube;

    private Vector3 playerPOS
    { get { return fov.playerRef.transform.position; } }

    private bool chasing 
    { get { return fov.canSeePlayer; } }

    private void Start()
    {
        fov = GetComponent<FieldOfView>();
        spriteAnim = GetComponentInChildren<Animator>();
        atp = GetComponent<AngleToPlayer>();
        agent = GetComponent<NavMeshAgent>();
        if (waypoints.Length != 0) UpdateDestination();
    }

    private void Update()
    {
        spriteAnim.SetFloat("spriteRot", atp.lastIndex);
        if (target != null && Vector3.Distance(transform.position, target) < 1 && !waiting && !chasing)
        {
            StartCoroutine(patrolWait());
        }

        if (chasing && Vector3.Distance(transform.position, playerPOS) > 2.5f )
        {
            agent.SetDestination(playerPOS);
        }
        if (chasing && Vector3.Distance(transform.position, playerPOS) < 2.5f && !attacking)
        {
            StartCoroutine(attack());
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

    private IEnumerator attack()
    { 
        attacking = true;
        yield return new WaitForSeconds(0.5f);
        atkCube.SetActive(true);
        yield return new WaitForSeconds(1f);
        atkCube.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        attacking = false;
    }

    private IEnumerator patrolWait()
    {
        waiting = true;
        yield return new WaitForSeconds(5f);
        if (!chasing)
        {
            IteratewaypointIndex();
            UpdateDestination();
            waiting = false;
        }
    }
}
