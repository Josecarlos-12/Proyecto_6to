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
    [SerializeField] GameObject one, two;

    [Header("Flash")]
    [SerializeField] private Animator animFlash;
    [SerializeField] private Collider collFlash, collNext;

    [Header("Audios")]
    [SerializeField] private AudioSource cat;
    [SerializeField] private AudioSource mike;
    [SerializeField] private AudioClip[] clipCat;
    [SerializeField] private GameObject aim;

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


            cam.SetActive(true);
            prota.SetActive(false);
            aim.SetActive(false);
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
        cat.clip = clipCat[0];
        cat.Play();
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: Mike, llama a la ambulancia! pero, ¿Cómo pudo pasar esto? ¡¿Dónde estabas tú?! ";
        yield return new WaitForSeconds(7);
        dialogue.SetActive(false);

        panel.SetActive(false);
        cam.SetActive(false);
        prota.SetActive(true);
    }

    public IEnumerator FLSB2()
    {
        dialogue.SetActive(true);
        cat.clip = clipCat[0];
        cat.Play();
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: Por favor, necesito que hablemos sobre lo que pasó, cariño, no puedo vivir así. Lo que pasó fue un accidente, solo quiero que juntos podamos superarl-";
        yield return new WaitForSeconds(9);
        mike.clip = clipCat[1];
        mike.Play();
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Te dije que no menciones más el tema!... ya sé lo que hice...";
        yield return new WaitForSeconds(5);
        dialogue.SetActive(false);

        panel.SetActive(false);
        cam.SetActive(false);
        prota.SetActive(true);
    }


    public IEnumerator FLSB3()
    {
        one.SetActive(true);
        two.SetActive(true);
        dialogue.SetActive(true);
        cat.clip = clipCat[0];
        cat.Play();
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: Ya no puedo más con todo esto... Lo siento Charlie... Perdóname Mike...";
        yield return new WaitForSeconds(9);
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
