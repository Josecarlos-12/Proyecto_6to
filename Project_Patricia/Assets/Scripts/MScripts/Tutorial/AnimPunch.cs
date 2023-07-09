using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimPunch : MonoBehaviour
{
    [SerializeField] private GameObject dialogue, eText, prota, cam, activeCol, panel, chapter;
    [SerializeField] private AudioSource audioChapter, punch, punch2;
    [SerializeField] private Collider col;
    [SerializeField] private bool into;
    [SerializeField] private Animator animDoor;

    public enum States
    {
        one, two
    }
    public States states;

    private void Update()
    {
        switch (states)
        {
            case States.one:

                break;
            case States.two:
                if(into && Input.GetKeyDown(KeyCode.E))
                {
                    animDoor.SetBool("Behind", true);
                    prota.SetActive(false);
                    cam.SetActive(true);
                    col.enabled = false;
                    into = false;
                    eText.SetActive(false);
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (states)
            {
                case States.one:
                    col.enabled = false;
                    StartCoroutine("ChapterOne");
                    break;
                case States.two:
                    into = true;
                    eText.SetActive(true);
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (states)
            {
                case States.one:

                    break;
                case States.two:
                    into = false;
                    eText.SetActive(false);
                    break;
            }
        }   
    }

    public IEnumerator ChapterOne()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Cat debe estar en el cuarto de Charlie cuidándolo";
        yield return new WaitForSeconds(3f);
        dialogue.SetActive(false);
        activeCol.SetActive(true);
        Destroy(gameObject);
    }

    public IEnumerator Dialogue()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Cat? ¿Charlie?";
        yield return new WaitForSeconds(3f);
        dialogue.SetActive(false);
    }

    public IEnumerator Final()
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(2f);
        audioChapter.Play();
        chapter.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Nivel 1");
    }

    public IEnumerator Punch()
    {
        punch2.Play();
        yield return new WaitForSeconds(0.2f);
        punch.Play();
    }

}
