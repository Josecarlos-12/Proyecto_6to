using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventFindCharlie : MonoBehaviour
{
    [SerializeField] private TasksUILevel2 taskCount;
    [SerializeField] private Collider coll, otherColl;
    [SerializeField] private GameObject text;
    [SerializeField] private Animator handle;
    public bool activeDorr;

    [Header("Call Other Script")]
    [SerializeField] private OpenDoorM openDoor;

    [Header("Audio")]
    [SerializeField] private AudioSource mike;
    [SerializeField] private AudioClip clip;

    [Header("TaskUI")]
    [SerializeField] private GameObject repeat;
    [SerializeField] private RepeatText repeatText;
    [SerializeField] private AudioClip clipRepeat;

    void Start()
    {
     this.gameObject.SetActive(false);   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            coll.enabled= false;
            taskCount.taskCount = 2;
            StartCoroutine("Dialogue");
        }
    }

    public IEnumerator Dialogue()
    {
        mike.clip= clip;
        mike.Play();

        openDoor.enabled= false;
        otherColl.enabled= false;
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Todo está muy tranquilo...";
        yield return new WaitForSeconds(3);
        text.SetActive(false);
        yield return new WaitForSeconds(2);
        repeat.SetActive(true);
        repeatText.clip= clipRepeat;
        repeatText.sText= "Mike Schmith: Mejor salgo y cierro la puerta para dejarlo descansar ";


        
        handle.SetBool("On", true);
        activeDorr= true;
    }
}
