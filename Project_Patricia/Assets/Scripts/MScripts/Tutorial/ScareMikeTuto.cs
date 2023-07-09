using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScareMikeTuto : MonoBehaviour
{
    [SerializeField] private GameObject shadowMike, point, otherCol, pointFinish;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Collider col;
    [SerializeField] private Animator anim;
    [SerializeField] private bool touch;

    private void Update()
    {
        if (touch)
        {
            agent.enabled = true;
            agent.destination = pointFinish.transform.position;
            anim.SetBool("Run", true);            
        }

        if (Vector3.Distance(shadowMike.transform.position, pointFinish.transform.position) < 3)
        {
            shadowMike.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine("Scare");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopCoroutine("Scare");
        }
    }


    public IEnumerator Scare()
    {
        yield return new WaitForSeconds(2);
        Destroy(otherCol);
        touch= true;        
        col.enabled= false;
        shadowMike.transform.position = point.transform.position;
        shadowMike.SetActive(true);        
    }
}
