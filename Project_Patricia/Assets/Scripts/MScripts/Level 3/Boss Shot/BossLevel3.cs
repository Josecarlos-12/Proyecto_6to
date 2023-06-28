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
    public GameObject container, rifle, rifle2;

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
    [SerializeField] private float soundGizmo;

    [Header("Call Other Script")]
    [SerializeField] private EventsBossLevel3 count;
    [SerializeField] private FeetsBossLevel3 feets;

    [Header("Follow Reset")]
    [SerializeField] private bool followReset;
    [SerializeField] private float timeF, maxTimeF;

    [Header("Raycast")]
    [SerializeField] private LayerMask layerPlayer;
    [SerializeField] private float distance;
    [SerializeField] private GameObject punch;
    [SerializeField] private Collider col;

    [Header("Transparency")]
    [SerializeField] private bool countShoot;
    [SerializeField] private Color myColor;
    [SerializeField, Range(0, 1)] private float myAlpha;
    [SerializeField] private SkinnedMeshRenderer charlie;
    [SerializeField] private float timeT, maxTimeT;
    [SerializeField] private AudioSource[] mikeAudio;
    [SerializeField] private GameObject door;
    [SerializeField] private AudioSource shootAudio;

    private void Update()
    {
        Follow();
        CountShoot();
        ShootBack(); 
        FollowReset();
        Transparency();
    }

    public void Transparency()
    {
        myColor.a = myAlpha;
        charlie.material.color = myColor;
        if (countShoot)
        {
            
            

            timeT += Time.deltaTime;

            if (timeT > maxTimeT)
            {
                timeT = 0;
                if (myAlpha > 0)
                {
                    myAlpha -= 0.2f;
                }

            }
        }       
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
                StartCoroutine("ResetCount");
                StopCoroutine("NoBullet");
            }
        }
    }

    public IEnumerator ResetCount()
    {
        
        countShoot = true;
        rifle.SetActive(false);
        col.enabled = false;
        animMike.SetBool("Death", true);
        yield return new WaitForSeconds(3);

        for (int i = 0; i < mikeAudio.Length; i++)
        {
            mikeAudio[i].Play();
        }
        door.SetActive(true);
        countShoot = false;
        myAlpha = 1;
        col.enabled= true;
        desactive = true;
        int range = Random.Range(0, pos.Length);
        transform.position = pos[range].position;
        print(range);
        yield return new WaitForSeconds(2);
        animMike.SetBool("Death", false); 
        back = 0;

        yield return new WaitForSeconds(4);
        count.life += 4;
        yield return new WaitForSeconds(4); 
        door.SetActive(false);
        for (int i = 0; i < mikeAudio.Length; i++)
        {
            mikeAudio[i].Stop();
        }
        desactive = false;
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
        if(desactive && Vector3.Distance(transform.position, player.position) < soundGizmo)
        {
            if(back<3)
            back++;

            if(back == 1)
            {

                for (int i = 0; i < mikeAudio.Length; i++)
                {
                    mikeAudio[i].Stop();
                }

                myAlpha = 1;
                door.SetActive(false);
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

            if (Vector3.Distance(transform.position, player.position) < size && !bBack && !feets.ladder)
            {
                
                //animMike.SetBool("Walk", true);
                agent.destination = player.position;
                StopCoroutine("FalseWalk");
                followReset = false;
                agent.stoppingDistance = 35;

                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, distance, layerPlayer))
                {
                    
                    if (hit.transform.CompareTag("Player"))
                    {
                        // Verifica si el raycast golpeó al jugador
                        if (shoot > 0)
                        {
                            Shoot();
                            Debug.Log(hit.transform.name);
                            // El raycast ha detectado al jugador
                            
                        }
                        agent.stoppingDistance = 35;
                    }              
                    else if (!hit.transform.CompareTag("Player"))
                    {
                        print(hit.transform.name);
                        print("Buscar");
                        agent.destination = player.position;
                        agent.stoppingDistance = 3;
                    }
                }

            }
            if (Vector3.Distance(transform.position, player.position) < size && !bBack && feets.ladder)
            {
                agent.destination = player.position;
                agent.stoppingDistance = 3;
            }
                if (Vector3.Distance(transform.position, player.position) < size && bBack)
            {
                //animMike.SetBool("Walk", true);
               /* followReset = false;
                Vector3 direction = transform.position - player.position;
                direction.Normalize();
                Vector3 targetPosition = transform.position + direction * distanceToPlayer;
                agent.SetDestination(targetPosition);

                StopCoroutine("FalseWalk");*/

                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, distance, layerPlayer))
                {
                    // Verifica si el raycast golpeó al jugador
                    if ( shoot > 0)
                    {
                        // El raycast ha detectado al jugador
                        Debug.Log("¡Jugador detectado!");
                        //Shoot();
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

            if(Vector3.Distance(transform.position, player.position) > sizeMove && Vector3.Distance(transform.position, player.position) < size && !bBack)
            {
                animMike.SetBool("Walk", true);
                animMike.SetBool("Punch", false);
            }
            else if ( bBack)
            {
                rifle.SetActive(false);
                rifle2.SetActive(true);
                animMike.SetBool("Punch", true);
            }
            else
            {
                rifle2.SetActive(false);
                punch.SetActive(false);
                animMike.SetBool("Punch", false);
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
        door.SetActive(true);
        back = 0;
        desactive = true;
        count.shootCount = 4;
        print("Se quedo sin balas");
        agent.enabled = false;
        animMike.SetBool("Walk", false);
        int range = Random.Range(0, pos.Length);
        transform.position = pos[range].position;

        for (int i = 0; i < mikeAudio.Length; i++)
        {
            mikeAudio[i].Play();
        }
        yield return new WaitForSeconds(4);
        myAlpha = 1;
        count.life += 4;
        yield return new WaitForSeconds(4);
        door.SetActive(false);
        for (int i = 0; i < mikeAudio.Length; i++)
        {
            mikeAudio[i].Stop();
        }
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
            shootAudio.Play();
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

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, soundGizmo);

    }
}
