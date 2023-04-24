using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyMoveRotate : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private float detectionFollow;
    public GameObject player, posInitial, pos;
    public bool touchEyes;
    [SerializeField] FollowOppositeDirection follow;
    [SerializeField] bool bFollow, touchColl, ret;
    [SerializeField] int touch; int i = 0;
    [SerializeField] GameObject enemyFollow;
    [SerializeField] PlayerCrouch crouch;
    [SerializeField] bool bCrouch;
    [SerializeField] GameObject container;

    public enum State
    {
        rotate, follow
    }
    public State state;
    private void OnDisable()
    {
        touch = 0;
    }

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        crouch = GameObject.FindObjectOfType<PlayerCrouch>();
    }


    void Update()
    {
        Follow();
    }

    public void Follow()
    {
        /*if (Vector3.Distance(transform.position, player.transform.position) < detectionFollow)
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
        }*/

        if (Vector3.Distance(transform.position, player.transform.position) < detectionFollow && !touchColl && !bCrouch)
        {
            if(touch<3)
            touch++;

            if (touch == 1)
            {
                StartCoroutine("FollowTime");
            }
        }
        if (Vector3.Distance(transform.position, player.transform.position) > detectionFollow)
        {
            touch = 0;
            StopCoroutine("FollowTime");
        }

        if(touchColl && crouch.crouch)
        {
            touch = 0;
            StopCoroutine("FollowTime");
            bCrouch= true;
        }
        else if (!crouch.crouch)
        {
            bCrouch = false;
        }


        if (follow.rotateR.r)
        {
            touch = 0;
            StopCoroutine("FollowTime");
            follow.transform.Rotate(0f, follow.rotationSpeed * -Time.deltaTime, 0f);
            touchColl = true;
        }
        else
        {
            touchColl = false;
        }

        if (follow.rotateL.l)
        {
            touch = 0;
            StopCoroutine("FollowTime");
            follow.transform.Rotate(0f, follow.rotationSpeed * Time.deltaTime, 0f);
            touchColl = true;
        }
        else
        {
            touchColl = false;
        }

    }

    public IEnumerator FollowTime()
    {
        yield return new WaitForSeconds(5);
        enemyFollow.transform.position = this.transform.position;
        enemyFollow.transform.rotation = this.transform.rotation;
        enemyFollow.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletPlayer"))
        {
            Destroy(container);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionFollow);
    }
}
