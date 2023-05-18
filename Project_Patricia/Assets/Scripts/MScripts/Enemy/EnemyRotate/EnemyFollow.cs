using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject prota, pointReturn;
    [SerializeField] private bool touch;
    [SerializeField] private GameObject enemyFollow, enemyRotate;
    [SerializeField] private bool follow;
    [SerializeField] GameObject container;

    [SerializeField] private Animator animCharlie;

    private void OnDisable()
    {
        touch = false;
    }


    private void Start()
    {
        prota = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (!touch)
        {
            agent.destination = prota.transform.position;
        }
        else
        {
            agent.destination = pointReturn.transform.position;
        }

        if(Vector3.Distance(transform.position, pointReturn.transform.position) < 3 && touch)
        {
            enemyFollow.SetActive(false);
            enemyRotate.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "DeEyes")
        {
            touch= true;
        }
        if (other.CompareTag("BulletPlayer"))
        {
            Destroy(container);
        }
    }
}
