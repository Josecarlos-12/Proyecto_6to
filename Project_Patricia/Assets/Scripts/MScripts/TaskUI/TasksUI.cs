using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TasksUI : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private TextMeshProUGUI textMesh;
    public string task;
    [SerializeField] private float time, mamxTime;
    public bool go;
    [SerializeField] private int count;
    public int taskCount=1;

    public enum TaskNumber
    {
        one, two
    }
    public TaskNumber number;
    
    void Update()
    {
        TaskActive();
        Tasks();

    }

    public void Tasks()
    {        
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
                switch (number)
                {
                    case TaskNumber.one:
                        StartCoroutine("TaskUIOff");
                        break; case TaskNumber.two:
                        StartCoroutine("TaskUIOff2");
                        break;
                }
                
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

    public IEnumerator TaskUIOff2()
    {
        yield return new WaitForSeconds(2);
        text.SetActive(true);
        textMesh.text = task;
        yield return new WaitForSeconds(3);
        text.SetActive(false);
        yield return new WaitForSeconds(18);
        count = 0;
    }
}
