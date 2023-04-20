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
    [SerializeField] private GameObject shadow, point;
    [SerializeField] private CrouchTutorial crTuto;
    [SerializeField] private GameObject coll;
    [SerializeField] private EnemyShed enemy;

    private void Update()
    {
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
        yield return new WaitForSeconds(0.6f);
        audioMike.clip = clip[0];
        audioMike.Play();
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Hey! ¿Quién eres tú? ¡¿Qué haces en mi propiedad?!";
        yield return new WaitForSeconds(4f);        
        dialogue.SetActive(false);
        run.run = true;        
        yield return new WaitForSeconds(1f);
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Hey hablo enserio, vuelve aquí!";
        audioMike.clip = clip[1];
        audioMike.Play();
        yield return new WaitForSeconds(3f);        
        dialogue.SetActive(false);
        yield return new WaitForSeconds(4f);
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Se está moviendo entre los arbustos...";
        audioMike.clip = clip[2];
        audioMike.Play();
        yield return new WaitForSeconds(2f);        
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Esta es mi oportunidad, tengo que evitar que me escuche";
        audioMike.clip = clip[3];
        audioMike.Play();
        yield return new WaitForSeconds(3f);       
        panel.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible= true;
        Cursor.lockState= CursorLockMode.None;

        shadow.transform.position = point.transform.position;

        dialogue.SetActive(false);
        this.gameObject.GetComponent<Rifle>().enabled = false;
    }

    public void AcceptButton()
    {
        enemy.accept = true;
        coll.SetActive(true);
        crTuto.active= true;
        panel.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible= false;
        Cursor.lockState = CursorLockMode.Locked;
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
