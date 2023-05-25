using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrabFlashBackV2 : MonoBehaviour
{
    public bool into, grab;
    [SerializeField] private GameObject textE;
    [SerializeField] private SleepMode sleep;
    [SerializeField] private Collider coll, collActive;


    [Header("Flb")]
    [SerializeField] GameObject panel;
    [SerializeField] GameObject dialogue, cam, prota;
    [SerializeField] AudioSource audi;
    [SerializeField] AudioClip[] clip;

    [Header("Flash")]
    [SerializeField] private Animator animFlash;
    [SerializeField] private Collider collFlash, collNext;

    public enum Dialogue
    {
        one, two, thre
    }
    public Dialogue textD;

    private void Update()
    {
        PressInput();
    }

    public void PressInput()
    {
        if (into && Input.GetKeyUp(KeyCode.E))
        {
            collFlash.enabled = false;
            animFlash.SetBool("On", false);
            animFlash.enabled = false;
            if (collNext != null)
            {
                collNext.enabled = true;
            }

            grab = true;
            textE.SetActive(false);
            coll.enabled = false;

            into = false;
            //sleep.ModeDreams();
            //StartCoroutine("OffDream");

            if (collActive != null)
            {
                collActive.enabled = true;
            }


            panel.SetActive(true);
            cam.SetActive(true);
            prota.SetActive(false);

            switch (textD)
            {
                case Dialogue.one:
                    StartCoroutine("FLSB");
                    break;
                case Dialogue.two:
                    StartCoroutine("FLSB2");
                    break;
                case Dialogue.thre:
                    StartCoroutine("FLSB3");
                    break;
            }
        }
    }

    public IEnumerator FLSB()
    {
        dialogue.SetActive(true);
        //audi.clip = clip[0];
        //audi.Play();
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: Mike, llama a la ambulancia! pero, �C�mo pudo pasar esto? ��D�nde estabas t�?! ";
        yield return new WaitForSeconds(4);
        dialogue.SetActive(false);

        panel.SetActive(false);
        cam.SetActive(false);
        prota.SetActive(true);
    }

    public IEnumerator FLSB2()
    {
        dialogue.SetActive(true);
        //audi.clip = clip[0];
        //audi.Play();
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: Por favor, necesito que hablemos sobre lo que pas�, cari�o, no puedo vivir as�. Lo que pas� fue un accidente, solo quiero que juntos podamos superarl-";
        yield return new WaitForSeconds(7);
       // audi.clip = clip[1];
        //audi.Play();
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: Mike: �Te dije que no menciones m�s el tema!... ya s� lo que hice...";
        yield return new WaitForSeconds(5);
        dialogue.SetActive(false);

        panel.SetActive(false);
        cam.SetActive(false);
        prota.SetActive(true);
    }


    public IEnumerator FLSB3()
    {
        dialogue.SetActive(true);
        //audi.clip = clip[0];
        //audi.Play();
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: Ya no puedo m�s con todo esto... Lo siento Charlie... Perd�name Mike...";
        yield return new WaitForSeconds(7);
        dialogue.SetActive(false);

        panel.SetActive(false);
        cam.SetActive(false);
        prota.SetActive(true);
    }


    public IEnumerator OffDream()
    {
        yield return new WaitForSeconds(3);
        sleep.OffDreams();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textE.SetActive(true);
            into = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textE.SetActive(false);
            into = false;
        }
    }
}
