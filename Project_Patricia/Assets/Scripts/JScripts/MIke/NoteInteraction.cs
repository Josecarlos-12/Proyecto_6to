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
    public int count = 0;
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

    [Header("Press")]
    [SerializeField] private GameObject texE;

    public NotesUI noteList;

   public enum Check
    {
        normal, work
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
            pageSound.Play();
            count++;
            col.enabled = false;
        }

        if (count == 1)
        {
            Time.timeScale = 0;
            imageNote.sprite = image;
            note.SetActive(true);
            text.text = noteText;
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
            texE.SetActive(false);
            switch (check)
            {
                case Check.normal:
                    print("no work");
                    break;
                case Check.work:
                    print(noteList.sNote.Count);
                    workInt = noteList.sNote.Count;
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
