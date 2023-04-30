using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShed : MonoBehaviour
{
    public NavMeshAgent agent;
    [SerializeField] private GameObject destination, text;
    public bool run, run2;
    [SerializeField] int intTouch;
    public bool accept, touch;
    public int count;
    public Head head;

    void Start()
    {
        agent= GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (run) 
        {
            agent.enabled = true; 
            agent.destination = destination.transform.position;
        }

        if (run2)
        {
            agent.destination = destination.transform.position;
        }          

        if(touch)
        {
            if(intTouch<3)
            intTouch++;

            if (intTouch == 1)
            {
                StartCoroutine("Dialogue");
            }
        }
    }       

    public IEnumerator Dialogue()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Conque ahí estás, ¡Hey, te estoy hablando a ti!";
        agent.enabled= true;
        run2 = true;
        yield return new WaitForSeconds(3);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Vuelve aquí, no te dejaré escapar!";
        yield return new WaitForSeconds(3);
        text.SetActive(false);
    }
}
