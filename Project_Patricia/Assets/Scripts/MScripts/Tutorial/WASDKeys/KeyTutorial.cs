using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTutorial : MonoBehaviour
{
    [SerializeField] private TasksUI task;
    [SerializeField] private GameObject panelTuto;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            panelTuto.SetActive(false);
            task.go = true;
        }
    }
}
