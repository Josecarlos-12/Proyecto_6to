using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class EventChildV2 : MonoBehaviour
{
    [SerializeField] private Collider coll;
    [SerializeField] private GameObject eventGame;
    [SerializeField] private GameObject active;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private int count;
    [SerializeField] private float time = 2;
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
        one, two, three, four, five, rifle
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
                    active.SetActive(true);
                    coll.enabled = false;
                    StartCoroutine("Dialogue");
                    break;
                case EnumAction.two:
                    
                    break;
                case EnumAction.three:
                    
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
}
