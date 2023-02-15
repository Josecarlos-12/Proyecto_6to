using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator anim;
    [SerializeField] private bool bDamage, detected, checkSphere;
    [SerializeField] private bool a, b, c, d;

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
    [SerializeField] private int intGroup, count, count1, count2, count3, iA , sphere;
    [SerializeField] private int randon;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Transparent();
        Move();
        if (agent.remainingDistance < 1 && !detected)
        {
            if(intGroup== 0)
            {
                GroupA();
            }
            if(intGroup== 1)
            {
                GroupB();
            }   
            if(intGroup== 2)
            {
                GroupC();
            }
            if (intGroup == 3)
            {
                GroupD();
            }

            randon = 0;
        }
        if (iA > 2)
        {
            checkSphere = true;
            agent.destination = player.transform.position;

            if(randon<3)
            randon++;

            if (randon == 1)
            {
                intGroup = Random.Range(0, 3);
            }
            sphere = 0;
        }
        else
        {
            if(sphere<3)
            sphere++;

            if (sphere == 1)
            {
                StartCoroutine("CheckSphereFalse");
            }            
        }
    }

    public IEnumerator CheckSphereFalse()
    {
        yield return new WaitForSeconds(2);
        checkSphere = false;
    }

    public void Transparent()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            myAlpha -= 0.05f;
        }
        myColor.a = myAlpha;
        boss.material.color = myColor;
    }

    public void GroupA()
    {
        if (iA < 3 && !a)
        {
            a= true;
            agent.destination = groupA[destPoint].position;
            
            
            if(count<3)
            count++;

            if (count == 1)
            {
                StartCoroutine(CA());
            }
        }        
    }

    public IEnumerator CA()
    {
        yield return new WaitForSeconds(8);
        count= 0;
        a= false;
        destPoint = (destPoint + 1) % groupA.Length;
        iA++;
    }

    public void GroupB()
    {
        if (iA < 3 && !a)
        {
            a= true;
            agent.destination = groupB[destPoint].position;

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
        yield return new WaitForSeconds(8);
        count1 = 0;
        a = false; 
        destPoint = (destPoint + 1) % groupB.Length;
        iA++;
    }

    public void GroupC()
    {
        if (iA < 3 && !a)
        {
            a= true;
            agent.destination = groupC[destPoint].position;

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
        yield return new WaitForSeconds(8);
        count2 = 0;
        a = false;
        destPoint = (destPoint + 1) % groupC.Length;
        iA++;
    }


    public void GroupD()
    {
        if (iA < 3 && !a)
        {
            a= true;
            agent.destination = groupD[destPoint].position;

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
        yield return new WaitForSeconds(8);
        count3 = 0;
        a = true;
        destPoint = (destPoint + 1) % groupD.Length;
        iA++;
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
                detected= false;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            iA = 0;
            destPoint = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, size);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, punch);
    }
}
