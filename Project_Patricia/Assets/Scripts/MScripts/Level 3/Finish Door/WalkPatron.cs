using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkPatron : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private Transform[] points;
    [SerializeField] private int destPoint = 0;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private int count;
    [SerializeField] private Animator animMike;

    [SerializeField] private CamFalseMove move;

    [SerializeField] Transform shadow, mikePos;

    [SerializeField] float size;
    public enum State
    {
        mike, cam
    }
    public State state;

    private void Update()
    {
        switch (state)
        {
            case State.mike:
                if (agent.remainingDistance < 1 && count <= points.Length - 1 && move.move)
                {
                    GotoNextPoint();

                }
                if(Vector3.Distance(mikePos.position, points[5].transform.position) < size)
                {
                    animMike.SetBool("Walk", false);
                }

                break; case State.cam:
                transform.LookAt(shadow.position);
                if(agent.enabled)
                {
                    if (agent.remainingDistance < 1 && count <= points.Length - 1 && move.moveCam)
                    {
                        GotoNextPoint();
                    }
                }                
                break;
        }

        
    }

    public void GotoNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }
        //transform.LookAt(points[destPoint]);
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
        count++;
        print(count);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, size);
    }

}
