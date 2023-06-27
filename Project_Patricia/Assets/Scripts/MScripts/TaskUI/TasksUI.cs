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
    public int count, countT ;
    public int taskCount=1;
    [SerializeField] private AudioSource audioTask;


    public enum TaskNumber
    {
        one, two, three
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
                        break; 
                    case TaskNumber.two:
                        StartCoroutine("TaskUIOff2");
                        break;
                    case TaskNumber.three:
                        StartCoroutine("TaskUIOff3");
                        break;
                }
                
            }
        }
    }

    public IEnumerator TaskUIOff()
    {
        yield return new WaitForSeconds(20);
        audioTask.Play();
        text.SetActive(true);
        textMesh.text= task;
        yield return new WaitForSeconds(8);
        text.SetActive(false);
        count = 0;
    }

    public IEnumerator TaskUIOff2()
    {
        yield return new WaitForSeconds(2);
        audioTask.Play();
        text.SetActive(true);
        textMesh.text = task;
        yield return new WaitForSeconds(8);
        text.SetActive(false);
        yield return new WaitForSeconds(18);
        count = 0;
    }

    public IEnumerator TaskUIOff3()
    {
        audioTask.Play();
        text.SetActive(true);
        textMesh.text = task;
        yield return new WaitForSeconds(8);
        text.SetActive(false);
        yield return new WaitForSeconds(18);
        count = 0;
    }
}
