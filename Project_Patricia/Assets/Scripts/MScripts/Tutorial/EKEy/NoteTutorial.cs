using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteTutorial : MonoBehaviour
{
    [SerializeField] GameObject tutorialN, note, panel;
    [SerializeField] AnimTrue finish;
    [SerializeField] int count;
    [SerializeField] private NotesUI noteUI;
    [SerializeField] private Animator off, animN;
    [SerializeField] private GameObject tuto;

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
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
            StartCoroutine("NotePanel");
        }
    }

    public IEnumerator NotePanel()
    {
        yield return new WaitForSeconds(2);
        panel.SetActive(true);
        yield return new WaitForSeconds(11);
        off.SetBool("Off", true);
        yield return new WaitForSeconds(0.5f);
        panel.SetActive(false);
        tuto.SetActive(true);
    }

    public IEnumerator ActivePanel()
    {
        yield return new WaitForSeconds(5);
        tutorialN.SetActive(true);
        yield return new WaitForSeconds(1.3f);
        noteUI.init = true;
        yield return new WaitForSeconds(5);
        animN.SetBool("Exit", true);
    }


    public void Accept()
    {
        tutorialN.SetActive(false);
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
