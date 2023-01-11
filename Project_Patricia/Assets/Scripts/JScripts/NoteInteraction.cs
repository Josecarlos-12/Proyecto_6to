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
    public string noteText;
    public TextMeshProUGUI text;

    [Header("Press")]
    [SerializeField] private GameObject texE;

    // Start is called before the first frame update
    void Start( )
    {

    }

    // Update is called once per frame
    void Update( )
    {
        Press();
    }

    public void Press( )
    {
        if ( into && Input.GetKeyDown(KeyCode.E)) 
        {
            count++;
        }

        if ( count == 1 )
        {
            Time.timeScale = 0;
            imageNote.sprite = image;
            note.SetActive(true);
            text.text = noteText;
        }
        if ( count == 2 )
        {
            traduction.SetActive(true);
        }
        if ( count == 3 )
        {
            traduction.SetActive(false);
        }
        if ( count == 4 )
        {
            Time.timeScale = 1;
            note.SetActive(false);
            count = 0;
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
