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
        openDoor.enabled= false;
        otherColl.enabled= false;
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Todo está muy tranquilo...";
        yield return new WaitForSeconds(3);
        text.SetActive(false);
        handle.SetBool("On", true);
        activeDorr= true;
    }
}
