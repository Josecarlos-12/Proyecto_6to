using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteTutorial : MonoBehaviour
{
    [SerializeField] GameObject tutorialN, note, panel;
    [SerializeField] AnimTrue finish;
    [SerializeField] int count;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(note == null)
        {
            if(count<3)
            count++;

            if (count == 1)
            {
                StartCoroutine("ActivePanel");
            }           
        }

        if(finish.finish && Input.GetKeyDown(KeyCode.N))
        {
            finish.finish = false; 
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            panel.SetActive(true);
        }
    }

    public IEnumerator ActivePanel()
    {
        yield return new WaitForSeconds(5);
        tutorialN.SetActive(true);
    }


    public void Accept()
    {
        tutorialN.SetActive(false);
        panel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
