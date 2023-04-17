using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class ChildMove : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform[] points;
    [SerializeField] private int destPoint = 0;
    [SerializeField] private int count = 0, countT;
    [SerializeField] private int countMax = 0;
    [SerializeField] private AudioSource hello;
    [SerializeField] private AudioClip shoot;
    [SerializeField] private GameObject rifle;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Next());
    }

    void Update()
    {
        if (agent.remainingDistance < 1 && countMax<=6)
        {
            GoToNextPoint();

            if (count < 3)
                count++;

            if (count == 1)
            {
                hello.Play();
                StartCoroutine(Next());
            }
        }
        if (agent.remainingDistance < 1 && countMax >= 6)
        {
            if (countT < 3)
                countT++;

            if (countT == 1)
            {
                hello.clip = shoot;
                hello.Play();
                rifle.SetActive(true);
            }
        }
    }

    public void GoToNextPoint()
    {        
       

        agent.destination = points[destPoint].position;
       
    }

    public IEnumerator Next()
    {
        yield return new WaitForSeconds(6);
        count = 0;
        destPoint = (destPoint + 1) % points.Length;
        countMax++;
        /*destPoint = 0;
        yield return new WaitForSeconds(5);
        destPoint = 1;
        yield return new WaitForSeconds(5);
        destPoint = 2;
        yield return new WaitForSeconds(5);
        destPoint = 3;
        yield return new WaitForSeconds(5);
        destPoint = 4;
        yield return new WaitForSeconds(5);
        destPoint = 5; 
        yield return new WaitForSeconds(5);
        destPoint = 6;
        yield return new WaitForSeconds(5);
        destPoint = 7;
        yield return new WaitForSeconds(5);
        destPoint = 8;
        yield return new WaitForSeconds(5);
        destPoint = 9;*/
    }
}
