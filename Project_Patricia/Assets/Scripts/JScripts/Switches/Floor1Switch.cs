using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static SpawnEmilio;

public class Floor1Switch : MonoBehaviour
{
    public GameObject[] Lights;
    public GameObject text, dialogue;
    public bool into;
    public bool on;
    public AudioSource switchSound;
    public Animator anim;
    public int count;
    public bool touch;

    [Header("Audio")]
    [SerializeField] private AudioSource mike;
    [SerializeField] private AudioClip clip;

    public enum States
    {
        good, bad
    }
    public States state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case States.good:
                Inpt();
                break;
                case States.bad:
                Bad();
                break;
        }
        
    }
    public void Inpt()
    {
        if (Input.GetKeyDown(KeyCode.E)&&into)
        {
            switchSound.Play();
            on = !on;
            if (on)
            {
                anim.SetBool("On", true);
                for (int i = 0; i < Lights.Length; i++)
                {
                    Lights[i].gameObject.SetActive(false);
                }
                
            }
            else
            {
                anim.SetBool("On", false);
                for (int i = 0; i < Lights.Length; i++)
                {
                    Lights[i].gameObject.SetActive(true);
                } 
            }
            
        }
    }

    public void Bad()
    {
        if (Input.GetKeyDown(KeyCode.E) && into)
        {
            switchSound.Play();
            on = !on;
            if (on)
            {
                touch = true;
                count++;

                if (count == 1)
                {
                    StartCoroutine("CBad");
                }
            }
            else
            {
                touch = true;
                count++;

                if (count == 1)
                {
                    StartCoroutine("CBad");
                }
            }
        }
    }

    public IEnumerator CBad()
    {
        mike.clip = clip;
        mike.Play();

        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Qué raro, ¿Por qué nada está funcionando hoy?";
        yield return new WaitForSeconds(2);
        dialogue.SetActive(false);
        touch= false;
        count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(this.gameObject.GetComponent<Floor1Switch>().enabled==true)
            {
                text.SetActive(true);
                into = true;
            }            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(false);
            into = false;
        }
    }
}
