using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CamFalseMove : MonoBehaviour
{
    [SerializeField] Animator cam;

    public bool move;
    public bool moveCam;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] private GameObject credits;
    [SerializeField] private Animator animMike;


    public void Move()
    {
        cam.enabled = false;
        StartCoroutine("Next");

    }

    public IEnumerator Next()
    {
        yield return new WaitForSeconds(1.35f);
        move = true;
        animMike.SetBool("Walk", true);
        yield return new WaitForSeconds(2f);
        moveCam= true;
        agent.enabled= true;
        yield return new WaitForSeconds(1f);
        credits.SetActive(true);
    }
}
