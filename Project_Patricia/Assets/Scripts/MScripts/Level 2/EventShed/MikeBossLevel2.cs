using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class MikeBossLevel2 : MonoBehaviour
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
    [SerializeField] int despoint;
    [SerializeField] GameObject[] points, pointsSeventy, pointsFourty, pointsTen;    
    [SerializeField] int tp, punch, damage, countOne;

    [Header("Light House")]
    [SerializeField] private GameObject[] pointsLightHouse;
    [SerializeField] private LightHouseMike lHouse;
    public bool offLight;

    [Header("Punch")]
    [SerializeField] Transform playerBack;
    [SerializeField] Animator anim, animCam;
    [SerializeField] bool bPunch;

    [Header("CountLife")]
    [SerializeField] int one, two, three;
    [SerializeField] private int stateMikeRandom;

    [SerializeField] private AudioSource attack;

    void Update()
    {
        AttackBossLife();
        Transparent();
    }

    public void AttackBossLife()
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
                    //Punch();
                    //StartCoroutine("Recovery");
                    Light_Punch();
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
                    //Punch();
                    Light_Punch_Life();
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
                    //Punch();
                    Light_Punch_Life();
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
                    //Punch();
                    Light_Punch_Life();
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
                anim.SetBool("Run", false);
                anim.SetBool("Punch", false);
                agent.speed = 0;
                myAlpha = 1;
                animCam.SetBool("Final", true);
                prota.SetActive(false);
                cam.SetActive(true);
                //prota.transform.position = pos.transform.position;
                //prota.transform.rotation = pos.transform.rotation;
            }
        }
    }

    public void Light_Punch()
    {
        stateMikeRandom = Random.Range(1, 3);

        if (stateMikeRandom == 1)
        {
            print("Golpe");
            Punch();
        }
        if (stateMikeRandom == 2)
        {
            agent.enabled = false;
            print("Apago luz");
            StartCoroutine("LightOff");
        }
    }

    public void Light_Punch_Life()
    {
         stateMikeRandom = Random.Range(1, 4);

        if (stateMikeRandom == 1)
        {
            print("Golpe");
            Punch();
        }
        if (stateMikeRandom == 2)
        {
            print("Apago luz");
            StartCoroutine("LightOff");
        }
        if (stateMikeRandom == 3)
        {
            print("Recupero vida");
            StartCoroutine("Recovery");
        }
    }

    public IEnumerator LightOff()
    {
        agent.speed = 0;
        agent.acceleration = 0;
        anim.SetBool("Run", false);
        anim.SetBool("Punch", false);
        anim.SetBool("OffLight", true);

        bPunch = true;
        List<Collider> disabledColliders = new List<Collider>();

        for (int i = 0; i < lHouse.col.Length; i++)
        {
            if (lHouse.col[i].enabled)
            {
                disabledColliders.Add(lHouse.col[i]);
            }
        }

        if (disabledColliders.Count > 0)
        {
            int randomIndex = Random.Range(0, disabledColliders.Count);
            Collider randomCollider = disabledColliders[randomIndex];
            print(randomCollider.transform.position);
            transform.position = new Vector3(randomCollider.transform.position.x + 5, randomCollider.transform.position.y, randomCollider.transform.position.z);
        }
        yield return new WaitForSeconds(1);
        offLight= true;
        yield return new WaitForSeconds(4);
        anim.SetBool("OffLight", false);
        stateMikeRandom = 0;

        offLight = false;
        bPunch = false;
        anim.SetBool("Run", false);
        anim.SetBool("Punch", false);
        tp = 0;
        countOne = 0;
        punch = 0;
        agent.speed = 0;
        agent.acceleration = 0;

    }

    public IEnumerator Recovery()
    {
        //int ran = Random.Range(0, pointsLightHouse.Length - 1);
        //transform.position = pointsLightHouse[ran].transform.position;
        //print(pointsLightHouse[ran].transform.parent);
        List<Collider> disabledColliders = new List<Collider>();

        for (int i = 0; i < lHouse.col.Length; i++)
        {
            if (!lHouse.col[i].enabled)
            {
                disabledColliders.Add(lHouse.col[i]);
            }
        }

        if (disabledColliders.Count > 0)
        {
            int randomIndex = Random.Range(0, disabledColliders.Count);
            Collider randomCollider = disabledColliders[randomIndex];
            print(randomCollider.transform.position);
            transform.position = new Vector3(randomCollider.transform.position.x + 5, randomCollider.transform.position.y, randomCollider.transform.position.z);
        }




        bPunch = true;
        yield return new WaitForSeconds(4);
        stateMikeRandom = 0;

        life += 4;
        bPunch = false;
        anim.SetBool("Run", false);
        anim.SetBool("Punch", false);
        tp = 0;
        countOne = 0;
        punch = 0;
        agent.speed = 0;
        agent.acceleration = 0;
        print("Se Curo");
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
        agent.enabled = true;
        anim.SetBool("Run", true);
        agent.speed = 30;
        agent.acceleration = 300;
        agent.destination = posProta;
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Punch", true);
        yield return new WaitForSeconds(1);
        stateMikeRandom = 0;
        agent.enabled = false;

        bPunch = false;
        anim.SetBool("Run", false);
        anim.SetBool("Punch", false);
        tp = 0;
        countOne = 0;
        punch = 0;
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
            StopCoroutine("Recovery");
            StopCoroutine("LightOff");
            agent.speed = 0;
            agent.acceleration = 0;

            if (damage < 3)
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
        yield return new WaitForSeconds(1);
        anim.SetBool("Damage", false);
        yield return new WaitForSeconds(2);
        change = false;
        myAlpha = 1;

        tp = 0;
        countOne = 0;
        punch = 0;
        bPunch = false;
        damage = 0;
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

        Destroy(character);

        //text.SetActive(true);
        //text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Tengo que...";
        //audioMike.clip = clip[0];
        //audioMike.Play();        
        yield return new WaitForSeconds(1);
        //text.SetActive(false);
        Destroy(gameObject);
    }

    public void ReduceTra()
    {
        change = true;
    }
}
