using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventary : MonoBehaviour
{
    public bool rifle, bPills, bKEy, bKeyComfi, spriteRifle;
    public GameObject sRifle, sKey, sPill;
    public Image image;
    public int pills, pillsTakes;
    public Text count;
    [SerializeField] private GameObject cam, prota, panel;
    [SerializeField] private bool one;
    public AudioSource boxMusic;
    public GameObject rifleCount;
    public GameObject boxForte;
    
    [Header("Call Other Script")]
    [SerializeField] private PlayerHealth sanity;
    [SerializeField] private EventKeyShadow rRifle;
    [SerializeField] private PanelPills panelPills;

    [Header("Dialogue")]
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject eventPills, eventSleep, eventLaders;
    public bool complete;
    public Animator keyPad, alarm;
    public GameObject otherPills;


    [Header("Audio")]
    [SerializeField] private AudioSource audioMike;
    [SerializeField] private AudioClip clip;

    public enum Dream
    {
        none, sleep
    }
    public Dream dream;

    void Start()
    {
        rifle= true;
        //image.sprite = sRifle;
        count.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            rifle = true;
            bPills = false;
            bKeyComfi = false;
            sPill.SetActive(false);
            sKey.SetActive(false);
        }
        if(rifle)
        {
            if (rRifle != null)
            {
                if (rRifle.canRifle || spriteRifle)
                {
                    count.text = string.Empty;
                    rifleCount.SetActive(true);
                    sRifle.SetActive(true);
                }
                else if (!rRifle.canRifle || !spriteRifle)
                {
                    count.text = string.Empty;
                    rifleCount.SetActive(false);
                    sRifle.SetActive(false);
                    bPills = false;
                    bKeyComfi = false;
                }
            }
            if (spriteRifle)
            {
                count.text = string.Empty;
                rifleCount.SetActive(true);
                sRifle.SetActive(true);
            }
            else if (!spriteRifle)
            {
                count.text = string.Empty;
                rifleCount.SetActive(false);
                sRifle.SetActive(false);
                bPills = false;
                bKeyComfi = false;
            }
        }

        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            rifle = false;
            bPills = true;
            bKeyComfi= false;
            rifleCount.SetActive(false);
            sRifle.SetActive(false);
            sKey.SetActive(false);
        }
        if(bPills)
        {
            if (pills > 0)
            {                
                sPill.SetActive(true);
                count.text = pills.ToString();
            }
            if (pills <= 0)
            {
                count.text = string.Empty;
                sPill.SetActive(false);
            }
        }


         if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            bKeyComfi = true;
            rifle = false;
            bPills= false;
            count.text = string.Empty;
            sPill.SetActive(false);
            sRifle.SetActive(false);
            rifleCount.SetActive(false);
        }
        if(bKeyComfi)
        {
            if (bKEy)
            {                
                sKey.SetActive(true);
                Debug.Log("Llaves");
            }
            else
            {
                sKey.SetActive(false);
            }
        }

        Pills();
    }

    public void Pills()
    {
        if(bPills && pills > 0 && Input.GetMouseButtonDown(0))
        {
            pills--;
            //Mas sanidad
            if(sanity.sanity < sanity.sanityMax)
            {
                sanity.sanity += 10;
            }
            

            switch (dream)
            {
                case Dream.none: break;
                    case Dream.sleep:
                    pillsTakes++;

                    if (pillsTakes == 3)
                    {
                        if (one)
                            return;
                        StartCoroutine("DialogueSleep");
                    }
                    break;
            }
        }
    }

    public IEnumerator DialogueSleep()
    {
        yield return new WaitForSeconds(0);
        audioMike.clip = clip;
        audioMike.Play();
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Oohhh... Creo que me siento mejor...Hmm no... no cerré... el... estudio";
        yield return new WaitForSeconds(12);
        panel.SetActive(true);
        yield return new WaitForSeconds(2);
        otherPills.SetActive(true);
        boxForte.SetActive(true);
        complete = true;
        eventPills.SetActive(true);
        eventSleep.SetActive(true);
        eventLaders.SetActive(true);
        text.SetActive(false);
        prota.SetActive(false);
        
        cam.SetActive(true);
        //Alarma
        keyPad.SetBool("On", true);
        alarm.SetBool("On", true);
    }
}
