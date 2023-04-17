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

    public enum EnumAction
    {
        one, two,three, four, five
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
            }
        }
    }


    public IEnumerator Dialogue()
    {
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
        dialogue.GetComponent<TextMeshProUGUI>().text = textTwo[0];
        yield return new WaitForSeconds(timeTwo[0]);
        dialogue.GetComponent<TextMeshProUGUI>().text = textTwo[1];
        yield return new WaitForSeconds(timeTwo[1]);
        dialogue.SetActive(false);
        Destroy(this.gameObject);
    }

    public IEnumerator DialogueSound()
    {        
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = textTwo[0];
        yield return new WaitForSeconds(timeTwo[0]);
        dialogue.SetActive(false);
        rifleSound.Play();
        yield return new WaitForSeconds(timeTwo[1]);
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = textTwo[1];
        yield return new WaitForSeconds(timeTwo[2]);
        dialogue.SetActive(false);
        active.SetActive(true);
        Destroy(this.gameObject);
    }
}
