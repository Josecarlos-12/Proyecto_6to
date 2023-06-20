using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;
using static UnityEngine.Rendering.DebugUI;
using Unity.VisualScripting;

public class iron : MonoBehaviour
{
    [SerializeField] private bool into;
    [SerializeField] private bool cF;
    [SerializeField] private int count;
    [SerializeField] private GameObject cam, prota, panel, textE, wornClothes, cleanClothes;
    public NotesUI note;
    [SerializeField] private NoteInteraction noteGrab;

    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip taskClip;

    public enum Check
    {
        three, four, nine
    }
    public Check check;

    [Header("trash")]
    [SerializeField] private GameObject trash;
    [SerializeField] private GameObject Point;
    [SerializeField] private PickableObject pick;
    [SerializeField] private PickUpObject pickObject;

    private void Start()
    {

    }

    private void Update()
    {
        Iron();

    }

    public void Iron()
    {
        if (into && Input.GetKeyDown(KeyCode.E) && count == 0 && noteGrab.grabNote)
        {
            count++;
            prota.SetActive(false);
            panel.SetActive(true);
            cam.SetActive(true);
            textE.SetActive(false);
            StartCoroutine(Next());
        }
    }

    public IEnumerator Next()
    {

        switch (check)
        {
            case Check.three:
                audioSource.PlayOneShot(audioClip);
                break;
            case Check.four:
                audioSource.PlayOneShot(audioClip);
                break;
            case Check.nine:
                audioSource.PlayOneShot(audioClip);
                break;
        }
        yield return new WaitForSeconds(1);
        Destroy(wornClothes);
        cleanClothes.SetActive(true);
        yield return new WaitForSeconds(4);
        prota.SetActive(true);
        panel.SetActive(false);
        cam.SetActive(false);
        switch (check)
        {
            case Check.three:
                note.check = 3;
                break;
            case Check.four:

                note.check = 4;
                cF = true;
                break;
            case Check.nine:
                trash.SetActive(true);
                pickObject.PickedObject = trash;
                trash.transform.parent = Point.transform;
                trash.transform.position = Point.transform.position;
                trash.GetComponent<Rigidbody>().useGravity = false;
                trash.GetComponent<Rigidbody>().isKinematic= true;
                pick.isPickable = false;
                note.check = 9;
                break;
        }
        yield return new WaitForSeconds(0.5f);

        switch (check)
        {
            case Check.three:
                audioSource.PlayOneShot(taskClip);//Aqui poner Sonidos 
                break;
            case Check.four:
                audioSource.PlayOneShot(taskClip);//Aqui poner Sonidos 
                break;
            case Check.nine:
                audioSource.PlayOneShot(taskClip);
                break;
        }
        
    }  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {            
            if (noteGrab.grabNote == true)
            {
                into = true;
                if (count == 0)
                {
                    textE.SetActive(true);
                }
            }
                        
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = false;
            textE.SetActive(false);
        }
    }
}
