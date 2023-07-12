using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventWPV2 : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject otherCol;
    [SerializeField] private GameObject obj, active;
    [SerializeField] private GameObject box, boxOne, chart, chartFall, walk;
    [SerializeField] private AudioSource chartSound;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject capsule, wall;
    [SerializeField] private GameObject cam, player;

    [Header("Call Other Script")]
    [SerializeField] private SleepMode sleep;

    [SerializeField] private AudioSource audioMike, audi, back;
    [SerializeField] private AudioClip[] clip;
    [SerializeField] private GameObject charlies;
    [SerializeField] private GameObject[] pills;
    [SerializeField] private GameObject taskUI;
    [SerializeField] private TasksUILevel2 tasks;
    [SerializeField] private Collider colBox;

    [SerializeField] private RepeatText repeatText;
    [SerializeField] private GameObject repeat;

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

    private void Update()
    {
        
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
                    Destroy(otherCol);
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
        audioMike.clip = clip[0];
        audioMike.Play();
        yield return new WaitForSeconds(5);
        text.SetActive(false);
        Destroy(gameObject);
    }

    public IEnumerator Lanter()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Tengo que volver";
        audioMike.clip = clip[0];
        audioMike.Play();
        yield return new WaitForSeconds(4);
        box.SetActive(true);
        boxOne.SetActive(true);
        text.SetActive(false);
        Destroy(gameObject);
    }


    public IEnumerator Box()
    {
        colBox.enabled= true;
        tasks.taskCount = 2;
        pills[0].SetActive(true);
        pills[1].SetActive(true);
        pills[2].SetActive(true);

        Destroy(charlies);

        back.Play();

        box.GetComponent<Collider>().enabled = false;
        boxOne.GetComponent<Collider>().enabled = false;
        chart.SetActive(false);
        active.SetActive(true);
        chartFall.SetActive(true);
        sleep.ModeDreams();
        chartSound.Play();
        yield return new WaitForSeconds(2);
        sleep.OffDreams();
        Destroy(gameObject);
    }

    public IEnumerator Chart()
    {
        //player.SetActive(false);
        //cam.SetActive(true);
        //anim.SetBool("Chart", true);
        //yield return new WaitForSeconds(3);
        //player.SetActive(true);
        //cam.SetActive(false);
        //
        //yield return new WaitForSeconds(1);
        wall.SetActive(false);
        walk.SetActive(true);
        yield return new WaitForSeconds(1);
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: �Papaaaaaaa! �Ayudameeeeeee!";
        audioMike.clip = clip[0];
        audioMike.Play();
        yield return new WaitForSeconds(2);
        capsule.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: �Charlie! �Ya voy!";
        audi.clip = clip[1];
        audi.Play();
        yield return new WaitForSeconds(2);    
        //taskUI.SetActive(true);
        //tasks.go = true;
        //tasks.task = "find out who is shouting";
        text.SetActive(false);
        yield return new WaitForSeconds(2);
        repeat.SetActive(true);
        //repeatText.clip= clip[1];
        //repeatText.sText = "Mike Schmith: �Charlie! �Ya voy!";
    }
}
