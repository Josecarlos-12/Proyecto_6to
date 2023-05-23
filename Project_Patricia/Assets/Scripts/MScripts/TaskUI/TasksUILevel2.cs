using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TasksUILevel2 : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private TextMeshProUGUI textMesh;
    public string task;
    [SerializeField] private float time, mamxTime;
    public bool go;
    [SerializeField] private int count;
    public int taskCount = 1;
    public int countT = 0;

    void Update()
    {
        TaskActive();
        Tasks();
    }

    public void Tasks()
    {
        if (taskCount == 2)
        {
            if (countT < 3)
            {
                countT++;
            }

            if (countT == 1)
            {
                go = false;
                count = 0;
                text.SetActive(false);
                StopCoroutine("TaskUIOff");
                this.gameObject.SetActive(false);
            }

        }
    }

    public void TaskActive()
    {
        if (go)
        {
            if (count < 3)
                count++;

            if (count == 1)
            {
                StartCoroutine("TaskUIOff");
            }
        }
    }

    public IEnumerator TaskUIOff()
    {
        text.SetActive(true);
        textMesh.text = task;
        yield return new WaitForSeconds(3);
        text.SetActive(false);        
        yield return new WaitForSeconds(20);
        count = 0;
    }

}
