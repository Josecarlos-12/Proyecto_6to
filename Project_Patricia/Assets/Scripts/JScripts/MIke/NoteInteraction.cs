using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    public int add = 0;
    public StrongBoxCode strongBox;
    [SerializeField] private AudioSource grabNoteSound;

    [Header("Press")]
    [SerializeField] private GameObject texE;

    public NotesUI noteList;

    [Header("TasksUI")]
    [SerializeField] private TasksUI task;
    [SerializeField] private Collider drawerCol;

    [Header("Move")]
    [SerializeField] private CameraLook cam;
    [SerializeField] private PlayerFPSt player;
    [SerializeField] private PlayerCrouch crouch;

    public enum Check
    {
        normal, work, dialogue, codeOne, codeTwo, codeThree
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
            crouch.crouchCan = false;
            cam.moveCamera = false;
            player.canWalk= false;

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
            //Time.timeScale = 0;
            imageNote.sprite = image;
            note.SetActive(true);
            text.text = noteText;
            texE.SetActive(false);
            
        }
        if (count == 2)
        {
            traduction.SetActive(true);            

            if(add<3)
            add++;

            if(add== 1)
            {
                noteList.sNote.Add(noteList.save);
                noteList.traducttionNote.Add(noteList.tSave);
            }
            
        }
        if (count == 3)
        {
            traduction.SetActive(false);
        }
        if (count == 4)
        {
            //Time.timeScale = 1;

            crouch.crouchCan = true;
            cam.moveCamera = true;
            player.canWalk = true;
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
                case Check.codeOne:
                    if(strongBox!=null)
                    strongBox.codeOne = true;

                    if(drawerCol!=null)
                        drawerCol.enabled=true;
                    break;
                case Check.codeTwo:
                    if (strongBox != null)
                        strongBox.codeTwo= true;
                    break;
                case Check.codeThree:
                    strongBox.codeThree= true;
                    break;
            }
            grabNoteSound.Play();
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
