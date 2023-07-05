using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CamLimitTouch : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private GameObject prota, cam;
    [SerializeField] private GameObject rotation;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private AudioSource mike;
    [SerializeField] private AudioClip clip;
    [SerializeField] private Transform point;

    public enum State
    {
        one, two, three
    }
    public State state;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            //cam.transform.rotation = rotation.transform.rotation;
            container.SetActive(true);
            prota.SetActive(false);
            switch (state)
            {
                case State.one:
                    cam.transform.rotation = this.transform.rotation;
                    cam.transform.position = prota.transform.position;
                    StartCoroutine("DialogueTrue");
                    break;
                case State.two:
                    cam.transform.rotation = this.transform.rotation;
                    cam.transform.position = point.position;
                    StartCoroutine("DialogueTrue2");
                    break;
                case State.three:
                    cam.transform.rotation = this.transform.rotation;
                    cam.transform.position = prota.transform.position;
                    StartCoroutine("DialogueTrue3");
                    break;
            }

            
        }   
    }

    public IEnumerator DialogueTrue()
    {
        yield return new WaitForSeconds(0.3f);
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: No puedo irme muy lejos, tengo cosas por hacer";
        yield return new WaitForSeconds(3);
        dialogue.SetActive(false);
    }

    public IEnumerator DialogueTrue2()
    {
        yield return new WaitForSeconds(0.3f);
        mike.clip = clip;
        mike.Play();
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: No puedo dejar que escape";
        yield return new WaitForSeconds(3);
        dialogue.SetActive(false);
    }

    public IEnumerator DialogueTrue3()
    {
        yield return new WaitForSeconds(0.3f);
        mike.clip = clip;
        mike.Play();
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: No puedo dejar que escape";
        yield return new WaitForSeconds(3);
        dialogue.SetActive(false);
    }
}
