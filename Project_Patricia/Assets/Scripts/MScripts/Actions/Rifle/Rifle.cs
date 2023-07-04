using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class Rifle : MonoBehaviour
{
    [SerializeField] private bool into;
    public bool canRifle;
    [SerializeField] private GameObject text;
    [SerializeField] private Collider col;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Inventary inve;

    [Header("Dialogue")]
    [SerializeField] private GameObject dialogue;
    [SerializeField] private EnemyShed run;
    [SerializeField] private AudioSource audioMike;
    [SerializeField] private AudioClip[] clip;

    public bool star;
    public int count;

    [Header("Tutorial")]
    [SerializeField] GameObject panel;
    [SerializeField] private GameObject shadow, point, colliders;
    [SerializeField] private CrouchTutorial crTuto;
    [SerializeField] private GameObject coll;
    [SerializeField] private EnemyShed enemy;
    [SerializeField] private Animator animCrouch;

    [Header("Don´t Move CTRL")]
    [SerializeField] GameObject gameCTRL;
    [SerializeField] AnimTrue animTrue;
    [SerializeField] PlayerFPSt player;
    [SerializeField] PlayerCrouch crouch;
    [SerializeField] private Head head;

    private void Update()
    {
        CTRLButton();
        InpuRifle();
       if (star)
        {            
            if (count < 3)
            {
                count++;
            }

            if (count == 1)
            {
                StartCoroutine("DialogueFinal");
            }
        }
    }

    public IEnumerator DialogueFinal()
    {
        player.canRun = false;
        yield return new WaitForSeconds(0.6f);
        run.run = true;
        audioMike.clip = clip[0];
        audioMike.Play();
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Hey! ¿Quién eres tú? ¡¿Qué haces en mi propiedad?!";
        yield return new WaitForSeconds(3f);        
        dialogue.SetActive(false);            
        yield return new WaitForSeconds(1f);
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Hey hablo enserio, vuelve aquí!";
        audioMike.clip = clip[1];
        audioMike.Play();
        yield return new WaitForSeconds(3f);        
        dialogue.SetActive(false);
        //yield return new WaitForSeconds(1f);
        //dialogue.SetActive(true);
        //dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Se está moviendo entre los arbustos...";
        //audioMike.clip = clip[2];
        //audioMike.Play();
        yield return new WaitForSeconds(2f);
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Esta es mi oportunidad, tengo que evitar que me escuche";
        audioMike.clip = clip[3];
        audioMike.Play();
        yield return new WaitForSeconds(3f);
        dialogue.SetActive(false);
        yield return new WaitForSeconds(2f);
        run.agent.enabled = false;
        run.run = false;
        run.anim.SetBool("Walk", false);
        gameCTRL.SetActive(true);

        
        //Time.timeScale = 0;
        //Cursor.visible= true;
        //Cursor.lockState= CursorLockMode.None;

        shadow.transform.position = point.transform.position;
        colliders.SetActive(true);

        enemy.accept = true;
        coll.SetActive(true);
        crTuto.active = true;
        player.canWalk = false;
        yield return new WaitForSeconds(1f);
        crouch.crouchCan = true;
        panel.SetActive(true);
         yield return new WaitForSeconds(11f);
        animCrouch.SetBool("Off", true);
        yield return new WaitForSeconds(0.4f);
         panel.SetActive(false);
    }

    public void AcceptButton()
    {        
        
        Time.timeScale = 1;
        Cursor.visible= false;
        Cursor.lockState = CursorLockMode.Locked;

        //Hago aparecer el UI CTRL--Detengo movimiento del personaje
        
        
    }

    public void CTRLButton()
    {
        if(animTrue.init && Input.GetKeyDown(KeyCode.LeftControl))
        {
            print("PresionoCTRL");
            animTrue.init = false;
            gameCTRL.transform.GetChild(0).GetComponent<Animator>().SetBool("Exit", true);
            //head.head = true;
            player.canWalk = true;
            this.gameObject.GetComponent<Rifle>().enabled = false;
        }
    }

    public IEnumerator CTRLOff()
    {
        yield return new WaitForSeconds(1.35f);
        gameCTRL.SetActive(false);

    }

    public void InpuRifle()
    {
        if (into && Input.GetKeyDown(KeyCode.E))
        {
            inve.rifle= true;
            col.enabled= false;
            text.SetActive(false);
            canRifle = true;
            weapon.shootTwo= true;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(true);
            into = true;                  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(false);
            into = true;
        }
    }
}
