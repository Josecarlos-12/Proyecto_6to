using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OneTask : MonoBehaviour
{
    [Header("Task")]
    [SerializeField] private TextMeshProUGUI textTask;
    [SerializeField] private GameObject taskUI, eventKey;
    [SerializeField] private int count;

    private void Update()
    {
        if(eventKey==null)
        {
            if(count<3)
            count++;

            if (count == 1)
            {
                StartCoroutine("Task");
            }            
        }
    }

    public IEnumerator Task()
    {
        yield return new WaitForSeconds(2);
        taskUI.SetActive(true);    
        textTask.text = "Retrieve the attic key";
        yield return new WaitForSeconds(8);
        taskUI.SetActive(false);
        textTask.text = string.Empty;
        Destroy(gameObject);
    }
}
