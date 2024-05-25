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

    private AudioSource aS;
    [SerializeField] private AudioClip calmAudio;
    [SerializeField] private AudioClip huntAudio;
    private bool huntSound = false;
    private bool calmSound = false;

    private bool chasing = false;
    private bool attacking = false;
    [SerializeField] GameObject atkCube;

    private Vector3 playerPOS
    { 
        get 
        { 
            if (fov.playerRef != null) return fov.playerRef.transform.position; 
            else return transform.position;
        } 
    }

    private bool seePlayer 
    { get { return fov.canSeePlayer; } }

    private void Start()
    {
        aS = GetComponent<AudioSource>();
        fov = GetComponent<FieldOfView>();
        spriteAnim = GetComponentInChildren<Animator>();
        atp = GetComponent<AngleToPlayer>();
        agent = GetComponent<NavMeshAgent>();
        if (waypoints.Length != 0) UpdateDestination();
    }

    private void Update()
    {
        if (!chasing && !calmSound)
        { 
            calmSound = true;
            huntSound = false;
            aS.clip = calmAudio;
            aS.Play();
        }
        if (chasing && !huntSound)
        {
            calmSound = false;
            huntSound = true;
            aS.clip = huntAudio;
            aS.Play();
        }

        spriteAnim.SetFloat("spriteRot", atp.lastIndex);

        if (!seePlayer && chasing)
        {
            StartCoroutine(chaseWait());
        }

        if (seePlayer && Vector3.Distance(transform.position, playerPOS) > 2.5f )
        {
            chasing = true;
            agent.SetDestination(playerPOS);
        }

        if (seePlayer && Vector3.Distance(transform.position, playerPOS) < 2.5f && !attacking)
        {
            StartCoroutine(attack());
        }

        if (waypoints != null && Vector3.Distance(transform.position, target) < 1 && !waiting && !chasing)
        {
            StartCoroutine(patrolWait());
        }
    }

    private void UpdateDestination()
    {
        if (waypoints.Length != 0)
        {
            target = waypoints[waypointIndex].position;
            agent.SetDestination(target);
        }
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
        }
        waiting = false;
    }

    private IEnumerator chaseWait()
    {
        yield return new WaitForSeconds(5f);
        if (!seePlayer)
        {
            chasing = false;
            UpdateDestination();
        }
    }
}
