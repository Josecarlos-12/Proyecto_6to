using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatelynMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private int count;
    public GameObject cat, player, container;
    [SerializeField] private Animator animCat, animdoor;
    [SerializeField] private bool follow;

    [Header("Punch")]
    [SerializeField] private GameObject punch;
    [SerializeField] private float sizeP;
    [SerializeField] private bool bPunch, touch;
    [SerializeField] private int pCount;


    [Header("Lanter Player")]
    [SerializeField] private Light lanter;
    [SerializeField] private GameObject lightsAll;

    [Header("Other Cat")]
    public GameObject catV2;
    public GameObject catChangePos;

    public enum state
    {
        none, catFollow
    }
    public state enumFollow;


    private void Start()
    {
        follow = true;
    }

    private void Update()
    {
        switch (enumFollow)
        {
            case state.catFollow:
                Follow();
                Punch();
                break;
            case state.none:
                break;
        }

        
    }

    public void Follow()
    {
        if (follow && !bPunch && !touch)
        {
            //agent.speed = 8;
            agent.stoppingDistance = 8;
            agent.destination = player.transform.position;
            //animCat.SetBool("Flash", false);
            animCat.SetBool("Walk", true);
            //punch.SetActive(false);
                
        }
    }

    public void Punch()
    {
        if(Vector3.Distance(new Vector3(transform.position.x, transform.position.y + 4, transform.position.z), player.transform.position) < sizeP)
        {
            
            bPunch = true;
            animCat.SetBool("Walk", false);
            animCat.SetBool("Punch", true);
        }
        else
        {
            bPunch = false;
            //animCat.SetBool("Walk", true);
            animCat.SetBool("Punch", false);
        }
    }

    public void TouchPunch()
    {
        punch.SetActive(true);
    }

    public void FalsePunch()
    {
        punch.SetActive(false);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "DeEyes")
        {
            if (lanter.enabled)
            {
                count++;
                if (count == 1)
                {
                    animdoor.SetBool("Close", true);
                    touch = true;
                    follow = false;
                    animCat.SetBool("Walk", false);
                    animCat.SetBool("Flash", true);
                    agent.speed = 0;
                    lanter.enabled = false;

                }
            }

        }

    }

    public IEnumerator Rotate()
    {
        yield return new WaitForSeconds(2);
        print("S");
        lightsAll.SetActive(true);
        
        //cat.transform.rotation = container.transform.rotation;
        //follow = true;               
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y+4,transform.position.z), sizeP);
    }
}
