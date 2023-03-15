using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EmilioPatrol : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform[] points;
    [SerializeField] private int destPoint = 0;
    [SerializeField] private int distancePoint = 1;
    [SerializeField] private float radius;
    private GameObject player;
    [SerializeField] private bool detected, colition;
    public int count = 0;
    public AudioSource childScream;
    public AudioClip childClip;
    [SerializeField] private float size = 2.5f;

    [Header("Call Other Script")]
    [SerializeField] private DetectedPlay2 small;
    [SerializeField] private DetectedPlay2 mediun;
    [SerializeField] private DetectedPlay2 big;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        if(player!= null)
        {
            if (agent.remainingDistance < distancePoint && !detected && !colition)
            {
                GoToNextPoint();
            }
            Detected();
        }
        Scream();
    }

    public void Scream()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < size)
        {

            if (count < 3)
                count++;

            if (count == 1)
            {
                //childScream.Play();
                StartCoroutine("Sillent");
            }
        }
    }

    public IEnumerator Sillent()
    {
        yield return new WaitForSeconds(3.5f);
        count = 0;
    }

    public void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
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
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, size);
    }
    
}
