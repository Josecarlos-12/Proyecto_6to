using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveBoss : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator anim;
    [SerializeField] private bool bDamage, detected, checkSphere;
    [SerializeField] private bool a, b, c, d;
    [SerializeField] private int countPosProta;
    [SerializeField] private Vector3 posProta;
    [SerializeField] private bool bullet;
    [SerializeField] private float life = 101;
    [SerializeField] private bool buOne;
    [SerializeField] private GameObject containerBoss;
    public bool lifeLess, death;
    [SerializeField] private GameObject boxInta;

    [Header("Distancias")]
    [SerializeField] private float size;
    [SerializeField] private float punch;

    [Header("trasparencia")]
    [SerializeField] private MeshRenderer boss;
    [SerializeField] private Color myColor;
    [SerializeField, Range(0, 1)] private float myAlpha;

    [Header("Randon")]
    [SerializeField] private Transform[] groupA;
    [SerializeField] private Transform[] groupB;
    [SerializeField] private Transform[] groupC;
    [SerializeField] private Transform[] groupD;
    [SerializeField] private int destPoint = 0;
    [SerializeField] private int intGroup, count, count1, count2, count3, iA, sphere;
    [SerializeField] private int randon;

    [Header("Teleport")]
    [SerializeField] private GameObject[] PosWay;
    [SerializeField] private int tCount;
    [SerializeField] private int rePos;
    [SerializeField] private GameObject tPosWay;
    [SerializeField] private Vector3 returPos;
    [SerializeField] private bool tp;

    [Header("Final")]
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject prota, pos;
    [SerializeField] private int countFinal;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnEnable()
    {
        
        

    }

    private void OnDisable()
    {
        tCount = 0;
        rePos= 0;
        myAlpha = 1;
        tp = true;
    }


    void Update()
    {
        Life();

        if (!death)
        {
            if (life <= 31)
            {
                lifeLess = true;
            }

            if (!buOne && life >= 71)
            {
                if (tp && life >= 71)
                {
                    tp = false;
                    tPosWay = PosWay[Random.Range(0, PosWay.Length)];

                    transform.position = tPosWay.transform.position;
                    transform.rotation = PosWay[Random.Range(0, PosWay.Length)].transform.rotation;
                }

                if (tCount < 3)
                    tCount++;

                if (tCount == 1)
                {
                    returPos = tPosWay.transform.position;

                    posProta = player.transform.position;
                    transform.LookAt(posProta);
                    agent.speed = 50;
                    agent.destination = posProta;
                }

                if (Vector3.Distance(transform.position, posProta) < 2)
                {
                    rePos = 1;
                }

                if (rePos == 1)
                {
                    agent.destination = returPos;
                }

                if (Vector3.Distance(transform.position, returPos) < 2)
                {
                    if (myAlpha >= 0)
                    {
                        myAlpha -= 0.01f;
                    }

                }

                if (myAlpha <= 0 && life >= 71)
                {
                    gameObject.SetActive(false);
                    
                }
            }

            Transparent();
            AttackOneTwo();
        }

       
    }

    public void AttackOneTwo()
    {
        if (!bullet)
        {
            if(life<=60)
            Move();

            if ( !detected && life <= 71 && agent.remainingDistance<1)
            {
                if (intGroup == 0)
                {
                    GroupA();
                }
                if (intGroup == 1)
                {
                    GroupB();
                }
                if (intGroup == 2)
                {
                    GroupC();
                }
                if (intGroup == 3)
                {
                    GroupD();
                }

                randon = 0;
                myAlpha = 1;
            }
            if (iA > 2)
            {
                checkSphere = true;

                if (randon < 3)
                    randon++;

                if (randon == 1)
                {
                    intGroup = Random.Range(0, 3);
                }

                // Guardar Posicion

                if (life >= 31)
                {
                    print("Life es mayo a 31");

                    if (countPosProta < 3)
                        countPosProta++;

                    if (countPosProta == 1)
                    {
                        transform.LookAt(posProta);
                        agent.speed = 50;
                        posProta = player.transform.position;
                    }


                    agent.destination = posProta;
                }

                if (life <= 31)
                {
                    print("Life es menor a 31");
                    myAlpha = 0;
                    transform.LookAt(player.transform.position);
                    agent.speed = 50;
                    agent.destination = player.transform.position;
                }
            }

            if (Vector3.Distance(transform.position, posProta) < 3 && life >= 31)
            {
                agent.speed = 30;
                countPosProta = 0;
                iA = 0;
                destPoint = 0;
            }
        }
    }

    public void Life()
    {
        if(life<=1)
        {
            agent.speed = 0;
            if (countFinal<3)
            countFinal++;

            if (countFinal == 1)
            {
                death = true;
                agent.speed = 0;
                myAlpha = 1;
                anim.SetBool("Final", true);
                prota.SetActive(false);
                cam.SetActive(true);
                prota.transform.position = pos.transform.position;
                prota.transform.rotation = pos.transform.rotation;
            }
           
        }
    }

    public IEnumerator ActiveProta()
    {
        prota.SetActive(true);
        cam.SetActive(false);
        GameObject intas = Instantiate(boxInta);
        intas.transform.position = transform.position;
        intas.SetActive(true);
        yield return new WaitForSeconds(1);
        Destroy(containerBoss);
    }

    public void Transparent()
    {
        myColor.a = myAlpha;
        boss.material.color = myColor;
    }

    public void Move()
    {
        if (player != null && !checkSphere)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < size && !bDamage)
            {
                transform.LookAt(player.transform.position);
                agent.destination = player.transform.position;
                agent.stoppingDistance = 2;
                detected = true;
            }
            else
            {
                detected = false;
                agent.stoppingDistance = 0;
            }

            if (Vector3.Distance(transform.position, player.transform.position) < punch)
            {
                transform.LookAt(player.transform.position);
                anim.SetBool("Punch", true);
                bDamage = true;
            }
            else
            {
                anim.SetBool("Punch", false);
                bDamage = false;
            }
        }
    }

    public IEnumerator CheckSphereFalse()
    {
        yield return new WaitForSeconds(2);
        checkSphere = false;
    }

    public void GroupA()
    {       
        if(iA < 3)
        {
            if (count < 3)
                count++;

            if (count == 1)
            {
                StartCoroutine(CA());
            }
        }
                      
    }

    public IEnumerator CA()
    {
        yield return new WaitForSeconds(2);
        destPoint = (destPoint + 1) % groupA.Length;
        agent.destination = groupA[destPoint].position;
        iA++;
        yield return new WaitForSeconds(0);
        count = 0;
    }

    public void GroupB()
    {
        if (iA < 3)
        {           
            if (count1 < 3)
                count1++;

            if (count1 == 1)
            {
                StartCoroutine(CB());
            }
        }
    }

    public IEnumerator CB()
    {
        yield return new WaitForSeconds(2);        
        destPoint = (destPoint + 1) % groupB.Length;
        agent.destination = groupB[destPoint].position;
        iA++;
        yield return new WaitForSeconds(0);
        count1 = 0;
    }

    public void GroupC()
    {
        if (iA < 3)
        {
            if (count2 < 3)
                count2++;

            if (count2 == 1)
            {
                StartCoroutine(CC());
            }
        }
    }
    public IEnumerator CC()
    {
        yield return new WaitForSeconds(2);        
        destPoint = (destPoint + 1) % groupC.Length;
        agent.destination = groupC[destPoint].position;
        iA++;
        yield return new WaitForSeconds(0);
        count2 = 0;
    }


    public void GroupD()
    {
        if (iA < 3)
        {
            if (count3 < 3)
                count3++;

            if (count3 == 1)
            {
                StartCoroutine(CD());
            }
        }
    }

    public IEnumerator CD()
    {
        yield return new WaitForSeconds(2);        
        destPoint = (destPoint + 1) % groupD.Length;
        agent.destination = groupD[destPoint].position;
        iA++;
        yield return new WaitForSeconds(0);
        count3 = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(life <= 31)
            {
                agent.speed = 30;
                countPosProta = 0;
                iA = 0;
                destPoint = 0;
            }
        }
    }

    public void TouchTriBoss()
    {

        if (life <= 71)
        {
            life -= 10;

            iA = 0;
            agent.speed = 0;
            countPosProta = 0;
            destPoint = 0;
            bullet = true;
            print("AnimacionTrue");
            StartCoroutine(BulletFalse());
        }

        if (life >= 71)
        {
            life -= 10;
            buOne= true;
            agent.speed = 0;
            print("AnimacionTrue");
            StartCoroutine(BuFalse());
        }
        
    }

    public IEnumerator BuFalse()
    {
        yield return new WaitForSeconds(3);
        buOne = false;
        agent.speed = 50;
        print("AnimacionFalse");
    }

    public IEnumerator BulletFalse()
    {
        yield return new WaitForSeconds(3);
        bullet = false;
        agent.speed = 50;
        print("AnimacionFalse");
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, size);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, punch);
    }
}
