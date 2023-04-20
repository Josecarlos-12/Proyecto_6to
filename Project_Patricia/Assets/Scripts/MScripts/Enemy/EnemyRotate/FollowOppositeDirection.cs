using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowOppositeDirection : MonoBehaviour
{
    /* public Transform player;
     private NavMeshAgent agent;
     public Transform rotate;
     public float size, speed;

     private void Start()
     {
         agent = GetComponent<NavMeshAgent>();
     }

     private void Update()
     {
         //Este podria servir
         if(Vector3.Distance(transform.position, player.position) < size)
         {
             Vector3 direction = transform.position - player.position;
             //agent.SetDestination(transform.position + direction);
         }


     }

     private void OnDrawGizmos()
     {
         Gizmos.color = Color.yellow;
         Gizmos.DrawWireSphere(transform.position, size);
     }*/

    public float rotationSpeed = 5f;

    private Vector3 previousPosition;

    public DetectedRotate rotateR;
    public RotateLeft rotateL;
    public int iR, iL;

    public GameObject enemy;
   
     

    public void Rotate()
    {
        if (rotateR.r)
        {
            transform.Rotate(0f, rotationSpeed * -Time.deltaTime, 0f);
        }
        if (rotateL.l)
        {
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        }
    }  
}
