using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class TPBossLevel1 : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Vector3 posProta;
    public float life = 101;

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
    [SerializeField] GameObject[] points, pointsSeventy, pointsFourty, pointsTen;
    [SerializeField] int despoint;
    [SerializeField] int tp, punch, damage, countOne;

    [Header("Punch")]
    [SerializeField] Transform playerBack;
    [SerializeField] Animator anim, animCam;
    [SerializeField] bool bPunch;

    [Header("CountLife")]
    [SerializeField] int one, two, three;

    [SerializeField] private AudioSource attack;
    [SerializeField] private GameObject eyes;
    [SerializeField] private Animator animEyes;
    [SerializeField] private GameObject rifle, aim;
    [SerializeField] private GameObject lanterPlayer, lanterRifle;



    [Header("Call Other Script")]
    [SerializeField] private TasksUILevel2 task;
    [SerializeField] private KeyGrab key;
    [SerializeField] private GameObject tasUI;
    [SerializeField] private WakingUpMode waking;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Inventary inventory;

    void Update()
    {
        AttackBossLife();
        Transparent();
    }

    public void AttackBossLife()
    {
        if (character != null)
        {
            if (life > 70)
            {
                if (countOne <= 6)
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

                    if (punch < 3)
                        punch++;

                    if (punch == 1)
                    {
                        Punch();
                    }
                }
            }

            if (life < 70 && life > 40)
            {
                if (one < 3)
                    one++;

                if (one == 1)
                {
                    despoint = 0;
                }




                if (countOne <= 4)
                {
                    transform.position = pointsSeventy[despoint].transform.position;

                    if (tp < 3)
                        tp++;

                    if (tp == 1)
                    {
                        StartCoroutine("TPCorutine");
                    }
                }
                else if (countOne > 3)
                {
                    change = false;
                    StopCoroutine("TPCorutine");

                    if (punch < 3)
                        punch++;

                    if (punch == 1)
                    {
                        Punch();
                    }
                }
            }

            if (life < 40 && life > 10)
            {
                if (two < 3)
                    two++;

                if (two == 1)
                {
                    despoint = 0;
                }



                if (countOne <= 2)
                {
                    transform.position = pointsFourty[despoint].transform.position;

                    if (tp < 3)
                        tp++;

                    if (tp == 1)
                    {
                        StartCoroutine("TPCorutine");
                    }
                }
                else if (countOne > 1)
                {
                    change = false;
                    StopCoroutine("TPCorutine");

                    if (punch < 3)
                        punch++;

                    if (punch == 1)
                    {
                        Punch();
                    }
                }
            }

            if (life < 10 && life > 1)
            {
                if (three < 3)
                    three++;

                if (three == 1)
                {
                    three = 0;
                }


                if (countOne <= 1)
                {
                    transform.position = pointsTen[despoint].transform.position;

                    if (tp < 3)
                        tp++;

                    if (tp == 1)
                    {
                        StartCoroutine("TPCorutine");
                    }
                }
                else if (countOne > 0)
                {
                    change = false;
                    StopCoroutine("TPCorutine");

                    if (punch < 3)
                        punch++;

                    if (punch == 1)
                    {
                        Punch();
                    }
                }
            }
        }
        

        if (life < 1)
        {
            agent.speed = 0;
            if (countFinal < 3)
                countFinal++;

            if (countFinal == 1)
            {
                agent.enabled= false;
                anim.SetBool("Run", false);
                anim.SetBool("Punch", false);
                agent.speed = 0;
                myAlpha = 1;
                animCam.SetBool("Final", true);
                Destroy(character);
                //prota.SetActive(false);
                //cam.SetActive(true);
                //prota.transform.position = pos.transform.position;
                //prota.transform.rotation = pos.transform.rotation;
            }
        }
    }

    public void Punch()
    {
        attack.Play();
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
        if (life > 70)
        {
            despoint = (despoint + 1) % points.Length;
        }
        if (life < 70 && life > 40)
        {
            despoint = (despoint + 1) % pointsSeventy.Length;
        }
        if (life < 40 && life > 10)
        {
            despoint = (despoint + 1) % pointsFourty.Length;
        }
        if (life < 10 && life > 1)
        {
            despoint = (despoint + 1) % pointsTen.Length;
        }


        change = false;
        
        countOne++;
        yield return TPCorutine();
    }
    
    public void TouchTriBoss()
    {        
        if (bPunch)
        {
            anim.SetBool("Damage", true);
            anim.SetBool("Run", false);
            anim.SetBool("Hit", false);
            anim.SetBool("Walk", false);
            anim.SetBool("OffLight", false);
            anim.SetBool("Punch", false);
            life -= 13;
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
            anim.SetBool("Damage", true);
            anim.SetBool("Run", false);
            anim.SetBool("Hit", false);
            anim.SetBool("Walk", false);
            anim.SetBool("OffLight", false);
            anim.SetBool("Punch", false);
            life -= 13;
            StartCoroutine("DamageFalse");
        } 
    }
    public IEnumerator DamageFalse()
    {
        yield return new WaitForSeconds(1);
        anim.SetBool("Damage", false);
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
        //boxInta.transform.position = transform.position;
        //boxInta.SetActive(true);

        

        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Tengo que...";
        //audioMike.clip = clip[0];
        //audioMike.Play();        
        yield return new WaitForSeconds(2);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Charlie";

        yield return new WaitForSeconds(2);
        text.SetActive(false);

        tasUI.SetActive(true);
        task.go = true;
        task.task = "Enter the attic";
        key.numberKey = 1;
        key.inve.bKEy = true;
        eyes.SetActive(false);
        yield return new WaitForSeconds(2);
        print("Des");
        Destroy(containerBoss);
    }

    public void ReduceTra()
    {
        eyes.SetActive(true);
        change = true; 
    }

    public void EyesClose()
    {
        lanterPlayer.SetActive(true);
        lanterRifle.SetActive(false);
        rifle.SetActive(false);
        aim.SetActive(false);
        inventory.spriteRifle = false;
        inventory.count.text = string.Empty;
        inventory.rifleCount.SetActive(false);
        inventory.sRifle.SetActive(false);
        inventory.bPills = false;
        inventory.bKeyComfi = false;

        weapon.shoot= false;
        weapon.shootTwo= false;
        waking.WakingOff();
        animEyes.SetBool("Open", true);
    }
}
