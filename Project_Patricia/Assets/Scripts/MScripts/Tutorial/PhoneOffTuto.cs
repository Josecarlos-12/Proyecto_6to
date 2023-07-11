using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhoneOffTuto : MonoBehaviour
{
    [SerializeField] bool into;
    [SerializeField] GameObject eText;
    [SerializeField] Collider col;
    [SerializeField] GameObject cam, prota, dialogue;
    [SerializeField] AudioSource phone;
    [SerializeField] AudioClip phoneClip;


    [SerializeField] private float[] time;
    [SerializeField, TextArea(4, 4)] private string[] text;
    [SerializeField] private AudioClip[] clip;
    [SerializeField] private AudioSource audioMike;
    [SerializeField] private AudioSource audioCatelyn;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private bool press;
    [SerializeField] private TasksUI task;
    [SerializeField] private Collider colNote;
    [SerializeField] private AudioClip mike, cat;

    private void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E))
        {
            into= false;
            eText.SetActive(false);
            col.enabled= false;
            phone.Stop();
            phone.loop=false;
            StartCoroutine("Dialogue");
        }
    }

    public IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(0.1f);
        phone.Stop();
        phone.clip= phoneClip;
        yield return new WaitForSeconds(1f);
        phone.volume = 0.3f;
        phone.Play();
        yield return new WaitForSeconds(1f);
        audioMike.clip = mike;
        audioMike.Play();
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: No era nadie cariño ";
        yield return new WaitForSeconds(3f);
        audioCatelyn.clip = cat;
        audioCatelyn.Play();
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: En serio? bueno";
        yield return new WaitForSeconds(3f);
        audioCatelyn.clip = clip[2];
        audioCatelyn.Play();
        textMeshPro.text = text[5];
        yield return new WaitForSeconds(time[6]);
        audioMike.clip = clip[3];
        audioMike.Play();
        textMeshPro.text = text[6];
        
        yield return new WaitForSeconds(time[7]);
        audioCatelyn.clip = clip[4];
        audioCatelyn.Play();
        textMeshPro.text = text[7];
        yield return new WaitForSeconds(time[8]);
        audioMike.clip = clip[5];
        audioMike.Play();
        textMeshPro.text = text[8];
        yield return new WaitForSeconds(time[9]);
        audioCatelyn.clip = clip[6];
        audioCatelyn.Play();
        textMeshPro.text = text[9];
        yield return new WaitForSeconds(time[10]);
        audioMike.clip = clip[7];
        audioMike.Play();
        textMeshPro.text = text[10];
        yield return new WaitForSeconds(time[11]);
        audioCatelyn.clip = clip[8];
        audioCatelyn.Play();
        textMeshPro.text = text[11];
        yield return new WaitForSeconds(time[12]);
        audioMike.clip = clip[9];
        audioMike.Play();
        textMeshPro.text = text[12];
        yield return new WaitForSeconds(time[13]);
        audioMike.clip = clip[10];
        audioMike.Play();
        textMeshPro.text = text[13];
        yield return new WaitForSeconds(time[14]);
        Destroy(cam);
        prota.SetActive(true);

        dialogue.SetActive(false);
        press = true;
        task.go = true;
        colNote.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = true;
            eText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = false;
            eText.SetActive(false);
        }
    }

}
