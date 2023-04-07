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

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
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
