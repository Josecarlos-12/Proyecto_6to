using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.HighDefinition;

public class Cushions : MonoBehaviour
{
    [SerializeField] private bool into;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject cam, prota, text, panel, objeDreams, posProta, rifle;
    [SerializeField] private NotesUI note;
    [SerializeField] private int count, count2, count3;
    [SerializeField] private SleepMode sleep;

    [SerializeField] private GameObject textDialogue;
    [SerializeField] private WakingUpMode wakingUp;
    [SerializeField] private AudioSource audioMike;
    [SerializeField] private AudioClip[] clip;

    [SerializeField] private GameObject rotDoor;
    [SerializeField] private Animator animDoor;
    [SerializeField] private OpenDoorM openDoor;
    [SerializeField] private TasksUI task;

    [Header("Don´t Move")]
    [SerializeField] private GameObject playerDontMove;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator[] doorAll;
    [SerializeField] private OpenDoorM[] openDoorScript;

    [SerializeField] private GameObject taskUI;
    [SerializeField] private AudioSource radio;

    [SerializeField] private GameObject sunRot;

    private void Update()
    {
        Down();
    }

    public void Down()
    {
        if(note.one && note.two && note.three && note.four && note.eight && note.nine && Input.GetKeyDown(KeyCode.E) && into)
        {  
            count++;

            if (count == 1)
            {
                task.taskCount = 2;
                rotDoor.transform.rotation= Quaternion.Euler(0,180,0);
                animDoor.enabled= false;
                openDoor.enabled= false;
                col.enabled = false;
                text.SetActive(false);
                prota.SetActive(false);
                cam.SetActive(true);                
                StartCoroutine(Next());
                StopCoroutine("After");
            }
                
        }

        if (note.one && note.two && note.three && note.four && note.eight && note.nine)
        {
            if(count2<3)
            count2++;

            if (count2 == 1)
            {
                StartCoroutine("After");
            }                
        }

        if(Vector3.Distance(playerDontMove.transform.position, transform.position) < 10 && playerDontMove.activeInHierarchy)
        {
            if(count3<3)
            count3++;

            if (count3 == 1)
            {
                task.taskCount = 2;
                rotDoor.transform.rotation = Quaternion.Euler(0, 180, 0);
                animDoor.enabled = false;
                openDoor.enabled = false;
                col.enabled = false;
                text.SetActive(false);
                prota.SetActive(false);
                cam.SetActive(true);
                StartCoroutine(Next());

                
            }
        }
    }

    public IEnumerator After()
    {
        yield return new WaitForSeconds(30);
        for (int i = 0; i < doorAll.Length; i++)
        {
            doorAll[i].SetBool("Open", true)
;
        }

        for (int i = 0; i < openDoorScript.Length; i++)
        {
            openDoorScript[i].enabled = false;
        }

        prota.SetActive(false);
        playerDontMove.transform.position = prota.transform.position;
        playerDontMove.transform.rotation=prota.transform.rotation;
        playerDontMove.SetActive(true);
        agent.destination=this.transform.position;
        playerDontMove.transform.LookAt(this.transform.position);
        //task.taskCount = 2;
        //rotDoor.transform.rotation = Quaternion.Euler(0, 180, 0);
        //animDoor.enabled = false;
        //openDoor.enabled = false;
        //col.enabled = false;
        //text.SetActive(false);
        //prota.SetActive(false);
        //cam.SetActive(true);
        //StartCoroutine(Next());
    }

    public IEnumerator Next()
    {
        for (int i = 0; i < doorAll.Length; i++)
        {
            doorAll[i].SetBool("Open", false);
        }
        for (int i = 0; i < openDoorScript.Length; i++)
        {
            openDoorScript[i].enabled= true;
        }
        playerDontMove.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        panel.SetActive(true);
        //objeDreams.SetActive(true);
        yield return new WaitForSeconds(2f);        
        sleep.motionBlur.active = false;
        sleep.cAberration.active = false;
        sleep.run.canRun = true;
        sleep.crouch.crouchCan = true;
        panel.SetActive(false);
        cam.GetComponent<Animator>().SetBool("Up", true);
        wakingUp.WakingOn();
        sunRot.transform.rotation = Quaternion.Euler(-0.54f, 81.328f, -0.812f);
        yield return new WaitForSeconds(1f);       
        rifle.SetActive(true);
        cam.SetActive(false); 
        prota.transform.position=posProta.transform.position;
        prota.transform.rotation = posProta.transform.rotation;
        radio.Stop();
        prota.SetActive(true);        
        yield return new WaitForSeconds(0.8f);       
        textDialogue.SetActive(true);
        textDialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Oooohhmm ¿Qué? ¿Qué hora es? debo cerrar el estudio.";
        audioMike.clip = clip[0];
        audioMike.Play();
        yield return new WaitForSeconds(9f);
        taskUI.SetActive(true);
        taskUI.GetComponent<TasksUI>().go = true;
        taskUI.GetComponent<TasksUI>().taskCount = 1;
        taskUI.GetComponent<TasksUI>().count = 0;
        taskUI.GetComponent<TasksUI>().countT = 0;
        taskUI.GetComponent<TasksUI>().number = TasksUI.TaskNumber.two;
        taskUI.GetComponent<TasksUI>().task = "Go to the studio";
        textDialogue.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (note.one && note.two && note.three && note.four && note.eight && note.nine)
            {
                into = true;
                text.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = false;
            text.SetActive(false);
        }
    }
}
