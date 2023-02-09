using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform[] points;
    [SerializeField] private int destPoint = 0;
    [SerializeField] private int distancePoint = 1;
    [SerializeField] private float radius;
    private GameObject player;
    [SerializeField] private bool detected, colition;

    [Header("Call Other Script")]
    [SerializeField] private DetectedPlayer small;
    [SerializeField] private DetectedPlayer mediun;
    [SerializeField] private DetectedPlayer big;

    void Start()
    {
        agent= GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {

        if (agent.remainingDistance < distancePoint && !detected && !colition)
        {
            GoToNextPoint();
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

        agent.destination = points[destPoint].position;
        destPoint=(destPoint+1) % points.Length;
    }

    public void Detected()
    {
        /*if(Vector3.Distance(transform.position, player.transform.position) < radius )
        {
            agent.destination = player.transform.position;
            detected= true;
            agent.speed = 10;
            agent.acceleration = 15;
            agent.stoppingDistance = 1;
        }
        else if (Vector3.Distance(transform.position, player.transform.position) > radius)
        {
            detected = false;
            agent.speed = 3.5f;
            agent.acceleration = 8;
            agent.stoppingDistance = 0;
        }*/
        if(small.small || mediun.mediun || big.big)
        {
            //transform.LookAt(player.transform.position);
            agent.destination = player.transform.position;
            detected = true;
            agent.speed = 10;
            agent.acceleration = 15;
            agent.stoppingDistance = 2;
            StopCoroutine("FalseFollow");
        }
        else
        {
            StartCoroutine("FalseFollow");
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
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "ReturnEnemy")
        {            
            colition = true;
            StartCoroutine(Col());
        }
    }

    public IEnumerator Col()
    {
        yield return new WaitForSeconds(3);
        colition= false;
        agent.destination = points[destPoint].position;
    }

}
