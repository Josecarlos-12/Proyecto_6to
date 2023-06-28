using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class CharlieGoThree : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Animator anim;
    public bool go, go2;
    [SerializeField] private GameObject three;
    [SerializeField] private int count;

    [Header("Dialogo")]
    [SerializeField] private GameObject text;

    [Header("Anim")]
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject prota;

    [SerializeField] private AudioSource audioMike;
    [SerializeField] private AudioClip[] clip;

    [SerializeField] private GameObject charlie;

    void Start()
    {
        agent= GetComponent<NavMeshAgent>();
        agent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            agent.enabled = true;
            go2 = true;
            anim.enabled= false;
        }                

        if(go2)
        {
            if (agent.remainingDistance < 1)
            {
                Go();
            }
        }

        if (Vector3.Distance(transform.position, three.transform.position)<2)
        {
            print("Llego al punto");
            if(count<3)
            count++;

            if (count == 1)
            {
                charlie.SetActive(false);
                StartCoroutine("Dialogue");
            }

        }
    }

    public void Go()
    {
        agent.destination = three.transform.position;
    }


    public IEnumerator Dialogue()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡T- Tú no eres Charlie!";
        audioMike.clip = clip[0];
        audioMike.Play();
        yield return new WaitForSeconds(3);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Charlie!";
        audioMike.clip = clip[1];
        audioMike.Play();
        yield return new WaitForSeconds(2);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith:  ¡¿Dónde estás?!";
        //audioMike.clip = clip[2];
        //audioMike.Play();
        yield return new WaitForSeconds(2);
        cam.SetActive(true);
        prota.SetActive(false);
        text.SetActive(false);
    }
}
