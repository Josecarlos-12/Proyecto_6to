using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChildCry : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    [SerializeField] private AudioSource cry, childScream;
    [SerializeField] private float size = 2.5f;
    private int count = 0;
    [SerializeField] private PlayerHealth health;
    [SerializeField] private bool follow;
    public int scream;
    [SerializeField] private GameObject col;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        health= FindObjectOfType<PlayerHealth>();
        StartCoroutine("Follow");
    }

    private void Update()
    {
        Scream();

        if (follow)
        {
            agent.destination = player.transform.position;

        }
        if (scream == 1)
        {
            Destroy(col); 
        }
    }

    public void Scream()
    {
        if(Vector3.Distance(transform.position,player.transform.position) < size)
        {
            scream = 1;

            if(count<3)
            count ++;

            if (count == 1)
            {
                cry.Stop();
                childScream.Play();
                StartCoroutine("Sillent");
            }
        }
    }

    public IEnumerator Sillent()
    {
        yield return new WaitForSeconds(3.5f);
        count = 0;
    }

 

  public IEnumerator Follow()
    {
        yield return new WaitForSeconds(0.5f);
        cry.Play();
        yield return new WaitForSeconds(1.5f);
        follow= true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, size);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BulletPlayer"))
        {
            Destroy(gameObject);
        }
    }

}
