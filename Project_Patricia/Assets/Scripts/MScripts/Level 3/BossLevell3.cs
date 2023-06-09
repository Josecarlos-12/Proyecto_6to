using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossLevell3 : MonoBehaviour
{
    [Header("Life")]
    [SerializeField] private float life;    

    [Header("Follow Player")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animMike;
    [SerializeField] private float size;
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 posPivot; 
    [SerializeField] private float posY;
    [SerializeField] private GameObject container, rifle;

    [Header("Shoot")]
    [SerializeField] private float time;
    [SerializeField] private float maxTime;

    
    private void Update()
    {
        Follow();
    }

    public void Follow()
    {
        
        //posPivot = new Vector3(container.transform.position.x, posY, container.transform.position.z);

        if (Vector3.Distance(transform.position, player.position) < size)
        {
            Shoot();
            //animMike.SetBool("Walk", true);
            agent.destination = player.position;
            StopCoroutine("FalseWalk");
        }
        else
        {
            StartCoroutine("FalseWalk");
        }

        if (Vector3.Distance(transform.position, player.position) < size && Vector3.Distance(transform.position, player.position) > 7)
        {
            transform.LookAt(player.position);
            animMike.SetTrigger("Shoot");
        }
    }

    public void Shoot()
    {
        time += Time.deltaTime;

        if(time > maxTime)
        {
            time = 0;
            animMike.SetBool("Shoot", true);
            print("Disparo");
        }
    }

    public void ShootFalse()
    {
        animMike.SetBool("Shoot", false);
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
    }
}
