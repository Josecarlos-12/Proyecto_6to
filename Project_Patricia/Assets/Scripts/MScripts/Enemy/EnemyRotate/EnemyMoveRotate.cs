using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveRotate : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private float detectionFollow;
    public GameObject player, posInitial;
    public bool touchEyes;
    [SerializeField] FollowOppositeDirection follow;

    public enum State
    {
        rotate, follow
    }
    public State state;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        switch (state)
        {
            case State.rotate:
                follow.Rotate();
                break;
            case State.follow:
                Follow();
                break;
        }
    }

    public void Follow()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < detectionFollow)
        {
            if(!touchEyes)
            {
                agent.destination = player.transform.position;
                transform.LookAt(player.transform.position);
            }
            else
            {
                agent.destination = posInitial.transform.position;
            }
        }
        if(Vector3.Distance(transform.position, posInitial.transform.position) < 3)
        {
            transform.rotation = posInitial.transform.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "DeEyes")
        {
            touchEyes= true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "DeEyes")
        {
            touchEyes= false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionFollow);
    }
}
