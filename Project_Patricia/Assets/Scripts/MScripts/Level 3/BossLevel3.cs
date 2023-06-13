using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossLevel3 : MonoBehaviour
{ 
    [Header("Follow Player")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animMike;
    [SerializeField] private float size;
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 posPivot; 
    [SerializeField] private float posY;
    [SerializeField] private GameObject container, rifle;

    [Header("Random TP")]
    [SerializeField] private Transform[] pos;
    [SerializeField] private int bTP;

    [Header("Shoot")]
    [SerializeField] private float time;
    [SerializeField] private float maxTime;
    [SerializeField] private int shoot = 5, maxShoot = 5;
    [SerializeField] private int noBullet;
    [SerializeField] private float backSize;
    [SerializeField] private bool bBack;
    [SerializeField] private float distanceToPlayer;

    [Header("Don´t Move")]
    [SerializeField] private float sizeMove;

    [Header("Call Other Script")]
    [SerializeField] private EventsBossLevel3 count;

    private void Update()
    {
        Follow();
        CountShoot();
    }

    public void CountShoot()
    {
        if(count.shootCount == 3)
        {
            if(bTP<3)
            bTP++;

            if (bTP == 1) 
            {
                print("Le dispararon 3 veces");
                agent.enabled= false;
                animMike.SetBool("Walk", false);
                int range = Random.Range(0, pos.Length);
                transform.position = pos[range].position;
                print(range);
                StartCoroutine("ResetCount");
            }
        }
    }

    public IEnumerator ResetCount()
    {
        yield return new WaitForSeconds(4);
        count.life += 4;
        yield return new WaitForSeconds(4);
        print("Reset");
        shoot = maxShoot;
        count.shootCount = 0;
        bTP = 0;
        agent.enabled = true;
    }

    public void Follow()
    {
        if (count.shootCount < 3)
        {
            //posPivot = new Vector3(container.transform.position.x, posY, container.transform.position.z);

            if (Vector3.Distance(transform.position, player.position) < size && !bBack)
            {
                
                animMike.SetBool("Walk", true);
                agent.destination = player.position;
                StopCoroutine("FalseWalk");

                if (shoot > 0)
                {
                    Shoot();
                }
            }
            if (Vector3.Distance(transform.position, player.position) < size && bBack)
            {
                animMike.SetBool("Walk", true);

                Vector3 direction = transform.position - player.position;
                direction.Normalize();
                Vector3 targetPosition = transform.position + direction * distanceToPlayer;
                agent.SetDestination(targetPosition);

                StopCoroutine("FalseWalk");

                if (shoot > 0)
                {
                    Shoot();
                }
            }
            else if (Vector3.Distance(transform.position, player.position) > size)
            {
                StartCoroutine("FalseWalk");
            }

            if(Vector3.Distance(transform.position, player.position) < backSize) 
            {
                bBack = true;
            }
            else
            {
                bBack = false;
            }


            if (Vector3.Distance(transform.position, player.position) > 3 && Vector3.Distance(transform.position, player.position) < sizeMove && !bBack)
            {
                animMike.SetBool("Walk", false);
            }

            if (Vector3.Distance(transform.position, player.position) < size && Vector3.Distance(transform.position, player.position) > 2)
            {
                transform.LookAt(player.position);
            }
        }

        if (shoot <= 0)
        {
            if (noBullet < 3)
                noBullet++;

            if (noBullet == 1)
            {
                StartCoroutine("NoBullet");
            }
        }
    }

    public IEnumerator NoBullet()
    {
        count.shootCount = 4;
        print("Se quedo sin balas");
        agent.enabled = false;
        animMike.SetBool("Walk", false);
        int range = Random.Range(0, pos.Length);
        transform.position = pos[range].position;
        yield return new WaitForSeconds(4);
        count.life += 4;
        yield return new WaitForSeconds(4);
        noBullet = 0;
        shoot = maxShoot;
        count.shootCount = 0;
        bTP = 0;
        agent.enabled = true;
    }

    public void Shoot()
    {
        time += Time.deltaTime;

        if (time > maxTime)
        {
            shoot--;
            rifle.SetActive(true);
            time = 0;
            animMike.SetBool("Shoot", true);
            print("Disparo");
        }
    }

    public IEnumerator FalseWalk()
    {
        yield return new WaitForSeconds(2);
        animMike.SetBool("Walk", false);
    }

    private void OnDrawGizmos()
    {
        //posPivot = new Vector3(transform.position.x, posY, transform.position.z);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, size);
        Gizmos.DrawWireSphere(transform.position, sizeMove);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, backSize);
        
    }
}
