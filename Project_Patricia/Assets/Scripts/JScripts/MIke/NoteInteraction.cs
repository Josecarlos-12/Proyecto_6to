using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class NoteInteraction : MonoBehaviour
{
    public bool into;
    public int count = 0, cNote;
    public Sprite image;
    public Image imageNote;
    public GameObject note;
    public GameObject traduction;
    [TextArea(4,4)]
    public string noteText;
    public TextMeshProUGUI text;
    public BoxCollider col;
    public int workInt;
    public AudioSource pageSound;
    public DialogueNote noteNote;
    public bool grabNote;

    [Header("Press")]
    [SerializeField] private GameObject texE;

    public NotesUI noteList;

    [Header("TasksUI")]
    [SerializeField] private TasksUI task;

    public enum Check
    {
        normal, work, dialogue
    }

    public Check check;

    void Update( )
    {
        Press();
    }

    public void Press( )
    {
        if (into && Input.GetKeyDown(KeyCode.E))
        {
            //pageSound.Play();
            count++;
            col.enabled = false;
        }

        if (count == 1)
        {
            print("Dialogo star");
            switch (check)
            {
                case Check.normal:
                    break;
                case Check.work:
                    noteNote.Dialogue();
                    break;
                case Check.dialogue:
                    noteNote.Dialogue();
                    break;
            }
            Time.timeScale = 0;
            imageNote.sprite = image;
            note.SetActive(true);
            text.text = noteText;
            texE.SetActive(false);
        }
        if (count == 2)
        {
            traduction.SetActive(true);
        }
        if (count == 3)
        {
            traduction.SetActive(false);
        }
        if (count == 4)
        {
            noteList.sNote.Add(noteList.save);
            Time.timeScale = 1;
            note.SetActive(false);
            
            switch (check)
            {
                case Check.normal:
                    print("no work");
                    break;
                case Check.work:
                    task.taskCount = 2;
                    print(noteList.sNote.Count);
                    workInt = noteList.sNote.Count;
                    grabNote = true;
                    break;
            }
            Destroy(gameObject);           
            //count = 0;
        }             
    }
    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.CompareTag("Player") )
        {
            into = true;
            texE.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ( other.gameObject.CompareTag("Player") )
        {
            into = false;
            Time.timeScale = 1;
            note.SetActive(false);
            traduction.SetActive(false);
            count = 0;
            texE.SetActive(false);
        }
    }
}
