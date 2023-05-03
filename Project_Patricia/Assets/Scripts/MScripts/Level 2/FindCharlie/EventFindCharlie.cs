using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventFindCharlie : MonoBehaviour
{
    [SerializeField] private TasksUILevel2 taskCount;
    [SerializeField] private Collider coll;
    [SerializeField] private GameObject text;


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
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Todo está muy tranquilo...";
        yield return new WaitForSeconds(4);
        text.SetActive(false);
    }
}
