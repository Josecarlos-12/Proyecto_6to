using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class ShadowCatAttack : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform[] points;
    [SerializeField] private int destPoint = 0;

    [SerializeField] private int count;
    [SerializeField] private Animator anim;

    [Header("Detected")]
    [SerializeField] private int countNoFollow;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform pointPlayer;
    [SerializeField] private LayerMask layer;
    [SerializeField] private float size, raycastDistance;
    [SerializeField] private bool detected;

    [Header("Transport")]
    [SerializeField] private int range;
    [SerializeField] private bool colition;
    [SerializeField] private int countCol;

    [SerializeField] private AudioSource soundDetected;
    [SerializeField] private AudioSource soundFollow;
    [SerializeField] private AudioSource soundMove;
    [SerializeField] private int countSound;


    [SerializeField] private Transform point;
    [SerializeField] private BoxSingLevel2 box;
    private void Update()
    {
        if (agent.enabled && !box.bBox)
        {
            if (agent.remainingDistance < 1 && !detected)
            {
                GoToNextPoint();
            }
        }
        Detected();
        Collition();
        GoPoint();
    }

    public void GoPoint()
    {
        if (!detected && box.bBox)
        {
            agent.destination = point.position;
        }
    }

    public void Detected()
    {

        if (detected && count == 0 && agent.enabled)
        {
            print("Player");
            agent.destination = player.transform.position;
            agent.speed = 10;
            agent.acceleration = 70;
            agent.stoppingDistance = 5f;
            anim.SetBool("Move", false);
            anim.SetBool("Attack", true);

            if(countSound<3)
            countSound++;

            if (countSound == 1)
            {
                soundDetected.Play();
                soundFollow.Play();
            }

            
        }

        if (Vector3.Distance(transform.position, player.transform.position) < size)
        {
            
            transform.LookAt(pointPlayer.transform.position);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, layer))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    detected = true;
                }
            }
        }
        else if (Vector3.Distance(transform.position, player.transform.position) > size && detected == true && count==0)
        {
            if(countNoFollow<3)
            countNoFollow++;

            if(countNoFollow == 1) 
            {
                StartCoroutine("FollowFalse");
            }            
        }
    }

    public void Collition()
    {
        if (colition)
        {
            countCol++;

            if (countCol == 1)
            {
                detected = false;
                agent.speed = 0;
                transform.position = points[range].position;
                //transform.rotation = points[range].rotation;
                anim.SetBool("Scare", false);
                anim.SetBool("Attack", false);
                //cat.GetComponent<Animator>().enabled = true;
            }
        }
    }

    public IEnumerator FollowFalse()
    {
        yield return new WaitForSeconds(3);
        soundFollow.Stop();
        anim.SetBool("Move", true);
        anim.SetBool("Attack", false);
        countNoFollow = 0;
        detected= false;
        if (box.bBox==false)
        {
            agent.destination = points[destPoint].position;
        }
        else
        {
            agent.destination = point.position;
        }

        
        agent.speed = 3.5f;
        agent.acceleration = 8;
        agent.stoppingDistance = 0;
        yield return new WaitForSeconds(3);
        countSound= 0;
    }

    public void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }
        soundMove.Play();
        anim.SetBool("Move", true);
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ReturnEnemy")
        {
            if(count<3)
            count++;

            if (count == 1)
            {
                soundMove.Stop();
                print("TRA");
                StopCoroutine("FollowFalse"); 
                anim.SetBool("Scare", true);
                agent.speed = 0;
                StartCoroutine(Col());
                agent.enabled = false;
            }
        }
    }

    public IEnumerator Col()
    {
        yield return new WaitForSeconds(2);
        colition = true;
        anim.SetBool("Attack", false);
        anim.SetBool("Scare", false);
        anim.SetBool("Move", false);
        range = Random.Range(0, points.Length - 1);
        count = 0;
        yield return new WaitForSeconds(3);
        anim.SetBool("Move", true);
        colition = false;
        countCol = 0;
        agent.enabled = true;
        if (agent.enabled)
        {
            if (box.bBox == false)
            {
                agent.destination = points[destPoint].position;
            }
            else
            {
                agent.destination = point.position;
            }
        }
        agent.speed = 3.5f;
        agent.acceleration = 8;
        agent.stoppingDistance = 0;
        yield return new WaitForSeconds(3);
        countSound = 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, size);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * raycastDistance);
    }

}
