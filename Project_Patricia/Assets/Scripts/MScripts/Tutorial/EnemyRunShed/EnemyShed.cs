using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShed : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private GameObject destination, text;
    public bool run, run2;
    [SerializeField] int touch;
    public bool accept;

    void Start()
    {
        agent= GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (run2)
        {
            agent.destination = destination.transform.position;
        }          
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name== "DeEyes" && accept)
        {
            touch++;

            if (touch == 0)
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
    }
}
