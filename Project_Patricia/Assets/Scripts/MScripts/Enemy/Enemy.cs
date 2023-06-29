using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform[] points;
    [SerializeField] private int destPoint = 0;
    [SerializeField] private int distancePoint = 1;
    [SerializeField] private float radius;
    private GameObject player;
    [SerializeField] private bool detected, colition, punch;
    [SerializeField] private Animator anim;
    [SerializeField] private int count;
    [SerializeField] private GameObject cat, container;

    [Header("Life")]
    [SerializeField] private float life = 100;

    [Header("Call Other Script")]
    [SerializeField] private DetectedPlayer small;
    [SerializeField] private DetectedPlayer mediun;
    [SerializeField] private DetectedPlayer big;
    [SerializeField] private AudioSource steeps;

    [SerializeField] private float size;

    public float raycastDistance = 10f;
    [SerializeField] private LayerMask layer;

    public enum State
    {
        normal, follow
    }
    public State state;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        switch (state)
        {
            case State.normal:
                if (agent.remainingDistance < distancePoint && !detected && count == 0)
                {
                    GoToNextPoint();
                }
                break;
                case State.follow:
                break;
        }
        
        Detected();
        Collition();
    }

    public void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }
        anim.SetBool("Move", true);        
        agent.destination = points[destPoint].position;
        destPoint=(destPoint+1) % points.Length;
    }

    public void Detected()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < radius )
        {
            transform.LookAt(player.transform.position);
            punch = true;
            anim.SetBool("Attack", true);
            // agent.destination = player.transform.position;
            //detected= true;
            //agent.speed = 10;
            //agent.acceleration = 15;
            //agent.stoppingDistance = 1;
        }
        else if (Vector3.Distance(transform.position, player.transform.position) > radius)
        {
            punch= false;
            anim.SetBool("Attack", false);
            //detected = false;
            //agent.speed = 3.5f;
            //agent.acceleration = 8;
            //agent.stoppingDistance = 0;
        }

        switch (state)
        {
            case State.normal:
                if (Vector3.Distance(transform.position, player.transform.position) < size)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
                    {
                        if (hit.collider.CompareTag("Player"))
                        {
                            //transform.LookAt(player.transform.position);
                            agent.destination = player.transform.position;
                            detected = true;
                            agent.speed = 10;
                            agent.acceleration = 70;
                            agent.stoppingDistance = 10;
                            StopCoroutine("FalseFollow");
                        }
                    }

                    
                }
                else
                {
                    StartCoroutine("FalseFollow");
                }
                break;
                case State.follow:
                
                agent.destination = player.transform.position;
                agent.speed = 10;
                agent.acceleration = 70;
                agent.stoppingDistance = 10;
                break;
        }
    }

    public IEnumerator FalseFollow()
    {
        yield return new WaitForSeconds(5);
        detected = false;
        agent.speed = 3.5f;
        agent.acceleration = 8;
        agent.stoppingDistance = 0;
    }

    public void Collition()
    {
        if(colition)
        {
            
            agent.speed = 0;
            transform.position = points[0].position;
            transform.rotation = points[0].rotation;
            cat.transform.rotation = Quaternion.Euler(0,180,0);
            anim.SetBool("Scare", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

        Gizmos.DrawLine(transform.position, transform.position + transform.forward * raycastDistance);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "ReturnEnemy")
        {
            count++;

            if (count == 1)
            {
                anim.SetBool("Scare", true);
                agent.speed = 0;
                StartCoroutine(Col());
            }
        }
        if (other.gameObject.CompareTag("BulletPlayer"))
        {
            life -= 10;
        }
    }

    public IEnumerator Col()
    {
        yield return new WaitForSeconds(3);
        colition = true;
        count = 0;
        yield return new WaitForSeconds(3);
        colition= false;
        agent.destination = points[destPoint].position;
    }

}
