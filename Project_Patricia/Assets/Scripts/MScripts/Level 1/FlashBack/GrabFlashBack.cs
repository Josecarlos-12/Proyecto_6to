using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static KeyCharlieDialogue;

public class GrabFlashBack : MonoBehaviour
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


    public enum Dialogue
    {
        one,two,thre
    }
    public Dialogue textD;

    private void Update()
    {
        PressInput();
    }

    public void PressInput()
    {
        if(into && Input.GetKeyUp(KeyCode.E))
        {
            grab = true;
            textE.SetActive(false);
            coll.enabled = false;
            
            into = false;
            //sleep.ModeDreams();
            //StartCoroutine("OffDream");

            if(collActive != null)
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
        audi.clip = clip[0];
        audi.Play();
        dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: Papi estoy cansado de jugar con mis juguetes, ¿Por qué no puedo salir a jugar?";
        yield return new WaitForSeconds(5);
        audi.clip = clip[1];
        audi.Play();
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Sabes que no puedes salir, estás enfermo";
        yield return new WaitForSeconds(4);
        dialogue.SetActive(false);

        panel.SetActive(false);
        cam.SetActive(false);
        prota.SetActive(true);
    }

    public IEnumerator FLSB2()
    {
        dialogue.SetActive(true);
        audi.clip = clip[2];
        audi.Play();
        dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Mira papá! Este eres tú, este soy yo y esta es mamá. Te gusta? Espero ser tan bueno como ella.";
        yield return new WaitForSeconds(9);
        dialogue.SetActive(false);

        panel.SetActive(false);
        cam.SetActive(false);
        prota.SetActive(true);
    }


    public IEnumerator FLSB3()
    {
        dialogue.SetActive(true);
        audi.clip = clip[3];
        audi.Play();
        dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: Papá ¿Me prestarías tu arma para cazarlo?";
        yield return new WaitForSeconds(7);
        audi.clip = clip[4];
        audi.Play();
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike: No es un juguete y no deberías estar preguntando esas cosas. Aún eres muy pequeño.";
        yield return new WaitForSeconds(5);
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
            into= true;
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
