using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TasksUI : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private string task;
    [SerializeField] private float time, mamxTime;
    public bool go;
    [SerializeField] private int count;
    public int taskCount=1;

    
    void Update()
    {
        TaskActive();
        Tasks();
    }

    public void Tasks()
    {
        if(taskCount== 1)
        {
            task = "Find the note in the kitchen";
        }
        if (taskCount == 2)
        {
            int countT = 0;

            if(countT < 3)
            {
                countT++;
            }            

            if (countT == 1)
            {
                go = false;
                count= 0;
                StopCoroutine("TaskUIOff");
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
        yield return new WaitForSeconds(20);
        text.SetActive(true);
        textMesh.text= task;
        yield return new WaitForSeconds(3);
        text.SetActive(false);
        count = 0;
    }
}
