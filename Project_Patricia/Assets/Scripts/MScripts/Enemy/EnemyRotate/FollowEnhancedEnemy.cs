using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowEnhancedEnemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform finish;
    [SerializeField] private bool follow;
    [SerializeField] private Animator animCharlie;

    [SerializeField] private float size;
    [SerializeField] private bool punch;
    [SerializeField] private float sizeFinish;

    [SerializeField] private PunchCharlie pCharlie;
    [SerializeField] private GameObject container;
    [SerializeField] private int count;
    [SerializeField] private bool death;

    [SerializeField] private SkinnedMeshRenderer charlie;
    [SerializeField] private float time, maxTime;

    [SerializeField] private Color myColor;
    [SerializeField, Range(0, 1)] private float myAlpha;

    private IEnumerator Start()
    {
        player = GameObject.FindGameObjectWithTag("HealthMike");
        yield return new WaitForSeconds(1);
        follow= true;
    }

    private void Update()
    {
        if (!death)
        {
            if (follow && !pCharlie.touch)
            {
                agent.destination = player.transform.position;
                transform.LookAt(player.transform.position);

                if (!punch)
                {
                    animCharlie.SetBool("Walk", true);
                }
            }

            if (Vector3.Distance(transform.position, player.transform.position) < size && !pCharlie.touch)
            {
                punch = true;
                animCharlie.SetBool("Walk", false);
                animCharlie.SetBool("Punch", true);
            }
            else
            {
                punch = false;
            }

            if (pCharlie.touch)
            {
                follow = false;
                agent.destination = finish.position;
                transform.LookAt(finish.position);
                animCharlie.SetBool("Walk", true);
                animCharlie.SetBool("Punch", false);
            }

            if (Vector3.Distance(transform.position, finish.position) < sizeFinish && pCharlie.touch)
            {
                if (count < 3)
                    count++;

                if (count == 1)
                {
                    agent.stoppingDistance = 0;
                    animCharlie.SetBool("Crouch", true);
                    StartCoroutine("Finish");
                }
            }
        }

        if (death)
        {
            myColor.a = myAlpha;
            charlie.material.color = myColor;

            time += Time.deltaTime;

            if (time > maxTime)
            {
                time = 0;
                if (myAlpha > 0)
                {
                    myAlpha -= 0.2f;
                }
                
            }
        }

        if (myAlpha <= 0.015f)
        {
            Destroy(container);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BulletPlayer"))
        {
            agent.speed = 0;
            death= true;
            animCharlie.SetBool("Death", true);
            animCharlie.SetBool("Crouch", false);
            animCharlie.SetBool("Walk", false);
            animCharlie.SetBool("Punch", false);            
            Destroy(other.gameObject);
        }
    }

    public IEnumerator Finish()
    {
        yield return new WaitForSeconds(1);
        Destroy(container);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, size);
    }
}
