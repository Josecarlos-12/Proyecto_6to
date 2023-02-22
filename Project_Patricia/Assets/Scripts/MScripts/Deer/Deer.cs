using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Deer : MonoBehaviour
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
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        Detected();
    }   

    public void Detected()
    {       
        if (small.small || mediun.mediun || big.big)
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
