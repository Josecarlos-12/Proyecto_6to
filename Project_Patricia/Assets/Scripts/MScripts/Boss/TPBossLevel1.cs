using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.AnimatedValues;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class TPBossLevel1 : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Vector3 posProta;
    [SerializeField] private float life = 101;

    [Header("trasparencia")]
    [SerializeField] private Material boss;
    [SerializeField] private Color myColor;
    [SerializeField, Range(0, 1)] private float myAlpha;
    public float time, maxTime;
    public bool change;

    [Header("Final")]
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject prota, pos;
    [SerializeField] private int countFinal;
    [SerializeField] private GameObject boxInta;
    [SerializeField] private GameObject containerBoss, character;
    [SerializeField] private GameObject text;

    [Header("TP")]
    [SerializeField] GameObject[] points;
    [SerializeField] int despoint;
    [SerializeField] int tp, punch, damage, countOne;

    [Header("Punch")]
    [SerializeField] Transform playerBack;
    [SerializeField] Animator anim;
    [SerializeField] bool bPunch;

    void Update()
    {
        AttackBossLife();
        Transparent();
    }

    public void AttackBossLife()
    {
        if(life > 70)
        {
            if(countOne <= 6)
            {
                transform.position = points[despoint].transform.position;

                if (tp < 3)
                    tp++;

                if (tp == 1)
                {
                    StartCoroutine("TPCorutine");
                }
            }            
            else if (countOne > 5)
            {
                change = false;
                StopCoroutine("TPCorutine");

                if(punch<3)
                punch++;

                if (punch == 1)
                {
                    Punch();                    
                }
            }
        }
    }

    public void Punch()
    {
        bPunch = true;
        transform.position = playerBack.position; 
        transform.rotation = playerBack.rotation;
        StartCoroutine("PunchCorutine");
    }

    public IEnumerator PunchCorutine()
    {
        //Insertar Grito
        yield return new WaitForSeconds(1);
        posProta = player.transform.position;
        transform.LookAt(posProta);
        yield return new WaitForSeconds(1);
        anim.SetBool("Run", true);
        agent.speed = 30;
        agent.acceleration = 300;
        agent.destination = posProta;
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Punch", true);
        yield return new WaitForSeconds(1);
        bPunch = false;
        anim.SetBool("Run", false);
        anim.SetBool("Punch", false);
        tp = 0;
        countOne = 0;
        punch= 0;
        agent.speed = 0;
        agent.acceleration = 0;
    }


    public IEnumerator TPCorutine()
    {
        time = 0;
        myAlpha = 1;
        change = true;
        yield return new WaitForSeconds(4);
        change = false;
        despoint = (despoint + 1) % points.Length;
        countOne++;
        yield return TPCorutine();
    }
    
    public void TouchTriBoss()
    {        
        if (bPunch)
        {
            anim.SetBool("Run", false);
            anim.SetBool("Punch", false);
            life -= 8;
            StopCoroutine("PunchCorutine");            
            agent.speed = 0;
            agent.acceleration = 0;

            if(damage<3)
            damage++;


            if (damage == 1)
            {
                StartCoroutine("DamageCorutine");
            }
        }
        else
        {
            life -= 8;
        } 
    }

    public IEnumerator DamageCorutine()
    {
        time = 0;
        myAlpha = 1;
        change = true;

        yield return new WaitForSeconds(3);
        change= false;
        myAlpha = 1;

        tp = 0;
        countOne = 0;
        punch = 0;
        bPunch = false;
        damage= 0;
    }

    public void Transparent()
    {
        myColor.a = myAlpha;
        boss.color = myColor;

        if (change)
        {
            time += Time.deltaTime;

            if (time >= maxTime)
            {
                time = 0;
                myAlpha -= 0.2f;
            }
        }
    }

    public IEnumerator ActiveProta()
    {

        prota.SetActive(true);
        cam.SetActive(false);
        boxInta.transform.position = transform.position;
        boxInta.SetActive(true);

        Destroy(character);

        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Tengo que...";
        //audioMike.clip = clip[0];
        //audioMike.Play();        
        yield return new WaitForSeconds(1);
        text.SetActive(false);
        Destroy(containerBoss);
    }
}
