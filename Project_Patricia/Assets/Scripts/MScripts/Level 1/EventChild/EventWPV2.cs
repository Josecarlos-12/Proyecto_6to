using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventWPV2 : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject obj, active;
    [SerializeField] private GameObject box, boxOne, chart, chartFall, walk;
    [SerializeField] private AudioSource chartSound;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject capsule;
    [SerializeField] private GameObject cam, player;

    [Header("Call Other Script")]
    [SerializeField] private SleepMode sleep;

    private void Start()
    {
        

        switch (type)
        {
            case Event.one:
                obj = this.gameObject;
                obj.SetActive(false);
                break;
            case Event.two:
                obj = this.gameObject;
                obj.SetActive(false);
                break;
            case Event.three:
                obj = this.gameObject;
                obj.SetActive(false);
                break;
            case Event.four:

                break;
        }
    }

    public enum Event
    {
        one, two, three, four
    }
    public Event type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (type) 
            { 
            case Event.one:
                    col.enabled = false;
                    StartCoroutine("WPoint1");
                    break;
                case Event.two:
                    col.enabled = false;
                    StartCoroutine("Lanter");
                    break;
                case Event.three:
                    StartCoroutine("Box");
                    break;
                case Event.four:
                    col.enabled = false;
                    StartCoroutine("Chart");
                    break;
            }
        }
    }

    public IEnumerator WPoint1()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text= "Mike Schmith: Tal vez Cat ya haya regresado y pueda ayudarme a buscarlo";
        active.SetActive(true);
        yield return new WaitForSeconds(3);
        text.SetActive(false);
        Destroy(gameObject);
    }

    public IEnumerator Lanter()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Tengo que volver";
        yield return new WaitForSeconds(2);
        box.SetActive(true);
        boxOne.SetActive(true);
        text.SetActive(false);
        Destroy(gameObject);
    }


    public IEnumerator Box()
    {
        box.GetComponent<Collider>().enabled = false;
        boxOne.GetComponent<Collider>().enabled = false;
        chart.SetActive(false);
        chartFall.SetActive(true);
        sleep.ModeDreams();
        chartSound.Play();
        yield return new WaitForSeconds(2);
        sleep.OffDreams();
        Destroy(gameObject);
    }

    public IEnumerator Chart()
    {
        player.SetActive(false);
        cam.SetActive(true);
        anim.SetBool("Chart", true);
        yield return new WaitForSeconds(3);
        player.SetActive(true);
        cam.SetActive(false);
        capsule.SetActive(true);
        yield return new WaitForSeconds(1);
        walk.SetActive(true);
        yield return new WaitForSeconds(1);
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Papaaaaaaa! ¡Ayudameeeeeee!";
        yield return new WaitForSeconds(2);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Charlie! ¡Ya voy!";
        yield return new WaitForSeconds(2);       
        text.SetActive(false);
        
    }
}
