using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotesUI : MonoBehaviour
{
    public GameObject note;
    public TextMeshProUGUI text;
    public bool bNote, intoNote;
    public List<string> sNote= new List<string>();
    public string save;
    public int noteCount;

    private void Update()
    {
        Note();
    }

    public void Note()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            bNote = !bNote;

            if (bNote)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
                note.SetActive(true);
            }
            if(!bNote)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
                note.SetActive(false);
            }
            
        }

        if(sNote.Count == 0)
        {
            text.text= string.Empty;
        }
        else if (sNote.Count !=0) 
        {
        text.text= sNote[noteCount];
        }

    }

    public void Next()
    {
        if (noteCount < sNote.Count-1)
        {
            noteCount ++;
        }        
    }

    public void Back()
    {
        if (noteCount > 0)
        {
            noteCount--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Note"))
        {
            intoNote = true;
            save = other.GetComponent<NoteInteraction>().noteText;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Note"))
        {
           intoNote= false;
        }
    }
}
