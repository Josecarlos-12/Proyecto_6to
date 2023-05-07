using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using static GrabFlashBack;

public class EnemyShed : MonoBehaviour
{
    public NavMeshAgent agent;
    [SerializeField] private GameObject destination, text;
    public bool run, run2;
    [SerializeField] int intTouch;
    public bool accept, touch;
    public int count;
    public Head head;

    public Animator anim;

    void Start()
    {
        agent= GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (run) 
        {
            agent.enabled = true; 
            transform.LookAt(destination.transform.position);
            agent.destination = destination.transform.position;
            anim.SetBool("Walk", true);
        }

        if (run2)
        {
            transform.LookAt(destination.transform.position);
            agent.destination = destination.transform.position;
            agent.speed = 23;
            anim.SetBool("Walk", false);
            anim.SetBool("Run", true);
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
        anim.SetBool("Walk", true);
        yield return new WaitForSeconds(3);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Vuelve aquí, no te dejaré escapar!";
        yield return new WaitForSeconds(3);
        text.SetActive(false);
    }

    public IEnumerator Dialogue2()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Maldición, hice demasiado ruido ";
        yield return new WaitForSeconds(2);
        touch = true;
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Conque ahí estás, ¡Hey, te estoy hablando a ti!";
        agent.enabled = true;
        run2 = true;
        anim.SetBool("Walk", true);
        yield return new WaitForSeconds(3);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Vuelve aquí, no te dejaré escapar!";
        yield return new WaitForSeconds(3);
        text.SetActive(false);
    }
}
