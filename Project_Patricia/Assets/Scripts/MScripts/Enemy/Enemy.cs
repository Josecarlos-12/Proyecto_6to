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
    [SerializeField] private GameObject cat, container , pointRota;
    [SerializeField] private Transform playerPoint;

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
    [SerializeField] private int range;
    [SerializeField] private int countCol, countFalse;

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
                if (agent.enabled)
                {
                    if (agent.remainingDistance < distancePoint && !detected && count == 0)
                    {
                        GoToNextPoint();
                    }
                }
                
                break;
                case State.follow:
                break;
        }
        
        Collition();

        if(agent.enabled)
        {
            Detected();
        }        
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
        switch (state)
        {
            case State.normal:
                if (Vector3.Distance(transform.position, player.transform.position) < size)
                {
                    transform.LookAt(playerPoint.position);
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, layer))
                    {
                        if (hit.collider.CompareTag("Player"))
                        {
                            print("DetectoPlayer");
                            agent.destination = player.transform.position;
                            detected = true;
                            agent.speed = 10;
                            agent.acceleration = 70;
                            agent.stoppingDistance = 10;
                            StopCoroutine("FalseFollow");

                            if (Vector3.Distance(transform.position, player.transform.position) < radius)
                            {
                                //transform.LookAt(player.transform.position);
                                punch = true;
                                anim.SetBool("Attack", true);
                            }
                        }
                    }

                    
                }
                else if (Vector3.Distance(transform.position, player.transform.position) > size && detected)
                {
                    if(countFalse<3)
                    countFalse++;

                    if(countFalse == 1)
                    {
                        print("DSASDA");
                        agent.destination = player.transform.position;
                        agent.speed = 10;
                        agent.acceleration = 70;
                        agent.stoppingDistance = 10;
                        StartCoroutine("FalseFollow");
                    }

                    
                }

                if (Vector3.Distance(transform.position, player.transform.position) > radius)
                {
                    punch = false;
                    anim.SetBool("Attack", false);
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
        countFalse=0;
        detected = false;
        if (agent.enabled)
        {
            agent.destination = points[destPoint].position;
        }
        
        agent.speed = 3.5f;
        agent.acceleration = 8;
        agent.stoppingDistance = 0;
    }

    public void Collition()
    {
        if(colition)
        {
            countCol++;

            if (countCol == 1)
            {
                agent.speed = 0;
                transform.position = points[range].position;
                //transform.rotation = points[range].rotation;
                anim.SetBool("Scare", false);
                //cat.GetComponent<Animator>().enabled = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

        Gizmos.DrawLine(transform.position, transform.position + transform.forward * raycastDistance);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, size);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "ReturnEnemy")
        {
            count++;

            if (count == 1)
            {
                //anim.SetBool("Scare", true);
                agent.speed = 0;
                StartCoroutine(Col());
                agent.enabled= false;
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
        anim.SetBool("Attack", false);
        range = Random.Range(0, points.Length - 1);
        colition = true;
        count = 0;
        yield return new WaitForSeconds(3);
        countCol = 0;
        agent.enabled = true;
        colition = false;
        if(agent.enabled)
        {
            agent.destination = points[destPoint].position;
        }        
        agent.speed = 3.5f;
        agent.acceleration = 8;
        agent.stoppingDistance = 0;
    }

}
