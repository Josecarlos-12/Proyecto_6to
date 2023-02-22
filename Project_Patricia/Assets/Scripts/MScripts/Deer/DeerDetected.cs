using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class DeerDetected : MonoBehaviour
{
    public bool small, mediun, big;
    [SerializeField] private GameObject[] colls;
    [SerializeField] private GameObject textContainer;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private int count;
    [SerializeField] private GameObject point;

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform[] points;
    [SerializeField] private int destPoint = 0;
    [SerializeField] private int distancePoint = 1;

    private void Update()
    {
        //TrueColls();

        if (agent.remainingDistance < distancePoint && small)
        {
            //GoToNextPoint();
        }
    }

    public void TrueColls()
    {
        switch (col)
        {
            case coll.small:
                if (small && !colls[0].activeInHierarchy)
                {
                    small = false;
                }
                break;
            case coll.mediun:
                if (mediun && !colls[1].activeInHierarchy)
                {
                    mediun = false;
                }
                break;
            case coll.big:
                if (big && !colls[2].activeInHierarchy)
                {
                    big = false;
                }
                break;
        }
    }

    public enum coll
    {
        small, mediun, big
    }
    [SerializeField] private coll col;


    private void OnTriggerStay(Collider other)
    {
        switch (col)
        {
            case coll.small:
                if (other.gameObject.CompareTag("Player"))
                {
                    agent.destination = point.transform.position;
                    small = true;
                    //StopCoroutine("NoRun");
                    if(count<3)
                    count++;

                    if (count == 3)
                    {
                        Insta();
                    }
                    Debug.Log("Toco el pequeño");
                }
                break;
            case coll.mediun:
                if (other.gameObject.CompareTag("Player"))
                {
                    mediun = true;
                    Debug.Log("Alerta");
                }
                break;
            case coll.big:
                if (other.gameObject.CompareTag("Player"))
                {
                    big = true;
                    text.text = "TOCO EL PLAYER";
                    textContainer.SetActive(true);
                    Debug.Log("Toco el grande");
                }
                break;
        }
    }

    public void Insta()
    {
        /*var cube = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        cube.GetComponent<MeshRenderer>().enabled = false;
        cube.GetComponent<Collider>().enabled = false;*/
    }


    public void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }


    private void OnTriggerExit(Collider other)
    {
        switch (col)
        {
            case coll.small:
                if (other.gameObject.CompareTag("Player"))
                {
                    //StartCoroutine("NoRun");
                    Debug.Log("dejo de tocar el pequeño");
                }
                break;
            case coll.mediun:
                if (other.gameObject.CompareTag("Player"))
                {
                    mediun = false;
                }
                break;
            case coll.big:
                if (other.gameObject.CompareTag("Player"))
                {
                    big = false;
                    textContainer.SetActive(false);
                    Debug.Log("dejo de tocar el grande");
                }
                break;
        }
    }



    public IEnumerator NoRun()
    {
        yield return new WaitForSeconds(20);
        small = false;
    }
}
