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
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: �Hey! �Qui�n eres t�? ��Qu� haces en mi propiedad?!";
        yield return new WaitForSeconds(4f);
        audioMike.clip = clip[0];
        audioMike.Play();
        dialogue.SetActive(false);
        run.run = true;        
        yield return new WaitForSeconds(1f);
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: �Hey hablo enserio, vuelve aqu�!";
        yield return new WaitForSeconds(3f);
        audioMike.clip = clip[1];
        audioMike.Play();
        dialogue.SetActive(false);
        yield return new WaitForSeconds(4f);
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Se est� moviendo entre los arbustos...";
        yield return new WaitForSeconds(2f);
        audioMike.clip = clip[2];
        audioMike.Play();
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Esta es mi oportunidad, tengo que evitar que me escuche";
        yield return new WaitForSeconds(3f);
        audioMike.clip = clip[3];
        audioMike.Play();
        dialogue.SetActive(false);
        this.gameObject.GetComponent<Rifle>().enabled = false;
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
