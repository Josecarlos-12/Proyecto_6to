using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LanterGrab : MonoBehaviour
{
    [SerializeField] private GameObject text, lanter, childMove;
    [SerializeField] private bool into;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject dialogueText, tutoLanter;
    [SerializeField] AnimTrue animLanter;
    [SerializeField] Animator anim;

    [Header("Audio")]
    [SerializeField] private AudioSource mike;
    [SerializeField] private AudioClip clip;

    private void Update()
    {
        LanterInput();
        Press();
    }

    public void Press()
    {
        if (into && Input.GetKeyDown(KeyCode.E))
        {
            //childMove.SetActive(true);
            lanter.SetActive(true);
            col.enabled = false;
            into= false;
            text.SetActive(false);
            Destroy(transform.GetChild(0).gameObject);
            StartCoroutine("Dialogue");
        }
    }

    public IEnumerator Dialogue()
    {
        mike.clip = clip;
        mike.Play();

        dialogueText.SetActive(true);
        dialogueText.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Charlie! Regresa! ¡Es peligroso que estes fuera!";
        yield return new WaitForSeconds(2);
        tutoLanter.SetActive(true);
        yield return new WaitForSeconds(1);
        dialogueText.SetActive(false);
       
    }

    public void LanterInput()
    {
        if(animLanter.finish && Input.GetKeyDown(KeyCode.F))
        {
            animLanter.finish = false;
            anim.SetBool("Exit", true);
            StartCoroutine("LanterCorutine");
        }
    }

    public IEnumerator LanterCorutine()
    {
        yield return new WaitForSeconds(1.30f);
        tutoLanter.SetActive(false);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(true);
            into= true;
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
