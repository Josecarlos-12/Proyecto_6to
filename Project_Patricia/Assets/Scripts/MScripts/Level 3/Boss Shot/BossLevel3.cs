using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
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
    public bool desactive;

    [Header("Shoot")]
    [SerializeField] private float time;
    [SerializeField] private float maxTime;
    [SerializeField] private int shoot = 5, maxShoot = 5;
    [SerializeField] private int noBullet;
    [SerializeField] private float backSize;
    [SerializeField] private bool bBack;
    [SerializeField] private float distanceToPlayer;

    [Header("ShootBack")]
    [SerializeField] private Transform pointBack;
    [SerializeField] private int back;

    [Header("Don´t Move")]
    [SerializeField] private float sizeMove;

    [Header("Call Other Script")]
    [SerializeField] private EventsBossLevel3 count;

    [Header("Follow Reset")]
    [SerializeField] private bool followReset;
    [SerializeField] private float timeF, maxTimeF;

    [Header("Raycast")]
    [SerializeField] private LayerMask layerPlayer;
    [SerializeField] private float distance;

    private void Update()
    {
        Follow();
        CountShoot();
        ShootBack(); 
        FollowReset();
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

        if( count.shootCount == 3 && shoot <= 0)
        {
            if (bTP < 3)
                bTP++;

            if (bTP == 1)
            {
                print("Le dispararon 3 veces");
                agent.enabled = false;
                animMike.SetBool("Walk", false);
                int range = Random.Range(0, pos.Length);
                transform.position = pos[range].position;
                print(range);
                StartCoroutine("ResetCount");
                StopCoroutine("NoBullet");
            }
        }
    }

    public IEnumerator ResetCount()
    {
        back = 0;
        desactive = true;
        yield return new WaitForSeconds(4);
        count.life += 4;
        yield return new WaitForSeconds(4);
        desactive= false;
        print("Reset");
        shoot = maxShoot;
        count.shootCount = 0;
        bTP = 0;
        agent.enabled = true;
        followReset = true;
    }

    public void FollowReset()
    {
        if(followReset)
        {
            timeF += Time.deltaTime;

            if(timeF > maxTimeF)
            {
                timeF = 0;
                agent.destination = player.position;
            }
        }
    }

    public void ShootBack()
    {
        if(desactive && Vector3.Distance(transform.position, player.position) < size)
        {
            if(back<3)
            back++;

            if(back == 1)
            {
                
                desactive = false;
                print("Reset");
                shoot = maxShoot;
                count.shootCount = 0;
                bTP = 0;
                agent.enabled = true;

                int position = Random.Range(0, 1);
                print(position);
                if (position == 0)
                {
                    transform.position = pointBack.transform.position;
                }
                else if (position == 1)
                {
                    agent.destination = player.position;
                }
            }
            
        }
    }

    public void Follow()
    {
        if (count.shootCount < 3)
        {
            //posPivot = new Vector3(container.transform.position.x, posY, container.transform.position.z);

            if (Vector3.Distance(transform.position, player.position) < size && !bBack)
            {
                
                //animMike.SetBool("Walk", true);
                agent.destination = player.position;
                StopCoroutine("FalseWalk");
                followReset = false;

                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, distance, layerPlayer))
                {
                    // Verifica si el raycast golpeó al jugador
                    if (hit.collider.CompareTag("Player") && shoot > 0)
                    {
                        // El raycast ha detectado al jugador
                        Debug.Log("¡Jugador detectado!");
                        Shoot();
                    }
                }

            }
            if (Vector3.Distance(transform.position, player.position) < size && bBack)
            {
                //animMike.SetBool("Walk", true);
                followReset = false;
                Vector3 direction = transform.position - player.position;
                direction.Normalize();
                Vector3 targetPosition = transform.position + direction * distanceToPlayer;
                agent.SetDestination(targetPosition);

                StopCoroutine("FalseWalk");

                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, distance, layerPlayer))
                {
                    // Verifica si el raycast golpeó al jugador
                    if (hit.collider.CompareTag("Player") && shoot > 0)
                    {
                        // El raycast ha detectado al jugador
                        Debug.Log("¡Jugador detectado!");
                        Shoot();
                    }
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

            if(Vector3.Distance(transform.position, player.position) > 13 && Vector3.Distance(transform.position, player.position) < size && !bBack)
            {
                animMike.SetBool("Walk", true);
            }
            else if (Vector3.Distance(transform.position, player.position) > 4 && Vector3.Distance(transform.position, player.position) < sizeMove &&  bBack)
            {
                animMike.SetBool("Walk", true);
            }

            if (Vector3.Distance(transform.position, player.position) > 4 && Vector3.Distance(transform.position, player.position) < sizeMove && !bBack)
            {
                animMike.SetBool("Walk", false);
            }

            if (Vector3.Distance(transform.position, player.position) < size-5 && Vector3.Distance(transform.position, player.position) > 2)
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
        back = 0;
        desactive = true;
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
        desactive= false;
        followReset = true;
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

        Gizmos.DrawLine(transform.position, transform.position + transform.forward * distance);

    }
}
