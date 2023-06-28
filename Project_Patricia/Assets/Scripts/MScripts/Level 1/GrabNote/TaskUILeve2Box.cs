using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskUILeve2Box : MonoBehaviour
{
    [SerializeField] private GameObject note;
    [SerializeField] private GameObject taskUi;
    [SerializeField] private TasksUILevel2 task;

    void Update()
    {
        if(note == null)
        {
            task.go = true;
            task.task = "Check the music box";
            taskUi.SetActive(true);
            enabled = false;
        }
    }
}
