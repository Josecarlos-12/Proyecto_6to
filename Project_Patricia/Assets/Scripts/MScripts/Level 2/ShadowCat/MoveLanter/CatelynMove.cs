using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatelynMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private int count;
    [SerializeField] private GameObject cat, player, container;
    [SerializeField] private Animator animCat;
    [SerializeField] private bool follow;

    [Header("Punch")]
    [SerializeField] private GameObject punch;
    [SerializeField] private float sizeP;
    [SerializeField] private bool bPunch;
    [SerializeField] private int pCount;


    private void Start()
    {
        follow = true;
    }

    private void Update()
    {
        Follow();
        Punch();
    }

    public void Follow()
    {
        if (follow && !bPunch)
        {
            //agent.speed = 8;
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
            animCat.SetBool("Walk", true);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "DeEyes")
        {
           
            count++;
            if(count== 1)
            {follow= false;
                animCat.SetBool("Walk", false);
                animCat.SetBool("Flash", true);
                agent.speed = 0;
                
            }            
        }
    }

    public IEnumerator Rotate()
    {
        yield return new WaitForSeconds(2);
        print("S");
        cat.transform.rotation = container.transform.rotation;
       // print(cat.transform.rotation);
        follow = true;               
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y+4,transform.position.z), sizeP);
    }
}
