using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class Cushions : MonoBehaviour
{
    [SerializeField] private bool into;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject cam, prota, text, panel, objeDreams, posProta, rifle;
    [SerializeField] private NotesUI note;
    [SerializeField] private int count;
    [SerializeField] private SleepMode sleep;

    [SerializeField] private GameObject textDialogue;
    [SerializeField] private WakingUpMode wakingUp;
    [SerializeField] private AudioSource audioMike;
    [SerializeField] private AudioClip[] clip;

    [SerializeField] private GameObject rotDoor;
    [SerializeField] private Animator animDoor;
    [SerializeField] private OpenDoorM openDoor;

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
                rotDoor.transform.rotation= Quaternion.Euler(0,180,0);
                animDoor.enabled= false;
                openDoor.enabled= false;
                col.enabled = false;
                text.SetActive(false);
                prota.SetActive(false);
                cam.SetActive(true);
                StartCoroutine(Next());
            }
                
        }
    }

    public IEnumerator Next()
    {
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
        yield return new WaitForSeconds(1f);       
        rifle.SetActive(true);
        cam.SetActive(false); 
        prota.transform.position=posProta.transform.position;
        prota.transform.rotation = posProta.transform.rotation;
        prota.SetActive(true);        
        yield return new WaitForSeconds(0.8f);       
        textDialogue.SetActive(true);
        textDialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Oooohhmm ¿Qué? ¿Qué hora es? debo cerrar el estudio.";
        audioMike.clip = clip[0];
        audioMike.Play();
        yield return new WaitForSeconds(9f);        
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
