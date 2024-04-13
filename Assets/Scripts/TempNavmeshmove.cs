using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class TempNavmeshmove : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    private int currPoint;
    private NavMeshAgent agent;
    Vector3 target;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            IteratewaypointIndex();
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        target = points[currPoint].position;
        agent.SetDestination(target);
    }
    void IteratewaypointIndex()
    {
        currPoint++;
        if (currPoint == points.Length)
        {
            currPoint = 0;
        }
    }
}
