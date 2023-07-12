using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventCapsuleAtico : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject capsule, step, key, mike;
    [SerializeField] private AudioSource scare;

    [SerializeField] private TasksUILevel2 task;
    [SerializeField] private GameObject taskUI;
    [SerializeField] private Animator animKeyBox;

    [Header("Audio")]
    [SerializeField] private AudioSource mikeAudio;
    [SerializeField] private AudioSource mikeCharlie;
    [SerializeField] private AudioClip[] clip;
    [SerializeField] private GameObject repeat;
    [SerializeField] private RepeatText repeatText;

    public enum Event
    {
        one, two, three
    }
    public Event eve;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            col.enabled = false;
            switch (eve)
            {
                case Event.one:
                    scare.Play();
                    StartCoroutine("Dialogue");
                    break;
                case Event.two:
                    StartCoroutine("Key");
                    break;

                case Event.three:
                    StartCoroutine("Pad");
                    break;
            }
        }
    }


    public IEnumerator Dialogue()
    {
        repeat.SetActive(false);
        task.taskCount = 2;
        mikeAudio.clip = clip[0];
        mikeAudio.Play();

        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Wah!";
        yield return new WaitForSeconds(2);
        text.SetActive(false);
        mike.SetActive(false);
        capsule.GetComponent<MeshRenderer>().enabled = false;
        capsule.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(2);
        mikeCharlie.clip = clip[1];
        mikeCharlie.Play();

        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Papá, ayudameee! ";
        yield return new WaitForSeconds(2);
        mikeCharlie.clip = clip[2];
        mikeCharlie.Play();

        text.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Tengo mucho miedo! ";
        yield return new WaitForSeconds(3);
        mikeAudio.clip = clip[3];
        mikeAudio.Play();

        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Tranquilo hijo, voy a sacarte de aquí ";
        yield return new WaitForSeconds(3);

        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Iré a buscar las llaves del ático, regreso enseguida ";
        //Aqui tarea        

        animKeyBox.SetBool("On", true);

        yield return new WaitForSeconds(4);
        key.SetActive(true);
        task.task = "Look for the keybox near the entrance";
        taskUI.SetActive(true);
        task.go = true;
        
        step.SetActive(true);
        text.SetActive(false);
        Destroy(gameObject);
    }

    public IEnumerator Key()
    {
        mikeAudio.clip = clip[0];
        mikeAudio.Play();

        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Llaves, llaves...";
        yield return new WaitForSeconds(2);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Llaves del ático, deberian estar junto a la entrada";
        yield return new WaitForSeconds(4);
        repeat.SetActive(true);        
        step.SetActive(true);
        text.SetActive(false);
        Destroy(gameObject);
    }

    public IEnumerator Pad()
    {
        repeat.SetActive(false);
        repeatText.texContainer.SetActive(false);

        animKeyBox.SetBool("On", false);

        mikeAudio.clip = clip[0];
        mikeAudio.Play();

        task.taskCount = 2;
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Y las llaves?";
        yield return new WaitForSeconds(2);

        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Dónde?";
        key.SetActive(true);
        yield return new WaitForSeconds(2);
        text.SetActive(false);
        Destroy(gameObject);
    }
}
