using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventChild : MonoBehaviour
{
    [SerializeField] private Collider coll;
    [SerializeField] private GameObject eventGame;
    [SerializeField] private GameObject active;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private int count;
    [SerializeField] private float time=2;
    [SerializeField, TextArea(4, 4)] private string text;

    [SerializeField, TextArea(4, 4)] private string[] textTwo;
    [SerializeField] private float[] timeTwo;
    [SerializeField] private AudioSource rifleSound;

    [Header("Shadow Charlie")]
    [SerializeField] private GameObject point;
    [SerializeField] private GameObject charlie, cam, prota, panel;
    [SerializeField] private Animator shadowAnim;
    
    [SerializeField] private AudioSource audioMike;
    [SerializeField] private AudioClip[] clip;

    public enum EnumAction
    {
        one, two,three, four, five,rifle
    }
    public EnumAction action;

    void Start()
    {
        eventGame = this.gameObject;
        eventGame.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (action)
            {
                case EnumAction.one:
                    break;
                case EnumAction.two:
                    active.SetActive(true);
                    Destroy(this.gameObject);
                    break;
                case EnumAction.three:
                    coll.enabled = false;
                    StartCoroutine("Dialogue");
                    break;
                case EnumAction.four:
                    coll.enabled = false;
                    StartCoroutine("DialogueTwo");
                    break;
                case EnumAction.five:
                    coll.enabled = false;
                    StartCoroutine("DialogueSound");
                    break;
                case EnumAction.rifle:
                    coll.enabled = false;
                    StartCoroutine("RifleEvent");
                    break;
            }
        }
    }


    public IEnumerator Dialogue()
    {
        audioMike.clip = clip[0];
        audioMike.Play();

        active.SetActive(true);
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = text;
        yield return new WaitForSeconds(time);
        dialogue.SetActive(false);
        Destroy(this.gameObject);
    }

    public IEnumerator DialogueTwo()
    {
        active.SetActive(true);
        dialogue.SetActive(true);

        audioMike.clip = clip[0];
        audioMike.Play();

        dialogue.GetComponent<TextMeshProUGUI>().text = textTwo[0];
        yield return new WaitForSeconds(timeTwo[0]);

        audioMike.clip = clip[1];
        audioMike.Play();

        dialogue.GetComponent<TextMeshProUGUI>().text = textTwo[1];
        yield return new WaitForSeconds(timeTwo[1]);
        dialogue.SetActive(false);
        Destroy(this.gameObject);
    }

    public IEnumerator DialogueSound()
    {
        audioMike.clip = clip[0];
        audioMike.Play();


        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = textTwo[0];
        yield return new WaitForSeconds(timeTwo[0]);
        dialogue.SetActive(false);
        rifleSound.Play();
        yield return new WaitForSeconds(timeTwo[1]);
        audioMike.clip = clip[1];
        audioMike.Play();


        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = textTwo[1];
        yield return new WaitForSeconds(timeTwo[2]);
        dialogue.SetActive(false);
        active.SetActive(true);
        Destroy(this.gameObject);
    }

    public IEnumerator RifleEvent()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = textTwo[0];
        yield return new WaitForSeconds(timeTwo[0]);
        dialogue.SetActive(false);
        yield return new WaitForSeconds(timeTwo[1]);
        charlie.SetActive(true);
        charlie.transform.position = point.transform.position;
        charlie.transform.rotation= point.transform.rotation;
        yield return new WaitForSeconds(timeTwo[2]);
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = textTwo[1];
        yield return new WaitForSeconds(timeTwo[3]);
        dialogue.SetActive(false);
        yield return new WaitForSeconds(timeTwo[4]);        
        panel.SetActive(true);
        prota.SetActive(false);
        cam.SetActive(true);
        yield return new WaitForSeconds(timeTwo[5]);      
        shadowAnim.enabled= true;
        panel.SetActive(false);
       // Destroy(this.gameObject);
    }
}
