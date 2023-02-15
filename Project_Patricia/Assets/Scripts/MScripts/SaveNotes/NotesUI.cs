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
    public Weapon weapon;
    public bool shoot;

    [SerializeField] private Pause pause;
    [SerializeField] private NoteInteraction work;
    [SerializeField] private int counWork;
    public int check;
    [SerializeField] private GameObject[] lines; 
    [SerializeField] private GameObject linesContainer; 

    private void Start()
    {
        shoot = true;
    }

    private void Update()
    {
        Note();
        
                
        if(Input.GetKeyDown(KeyCode.B))
        {
            check++;
        }
        CheckList();
    }

    public void Note()
    {
        if(Input.GetKeyDown(KeyCode.L) && !pause.isPaused)
        {
            bNote = !bNote;

            if (bNote)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
                note.SetActive(true);
                shoot = false;
               
            }
            if(!bNote)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
                note.SetActive(false);
                shoot = true;
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

    public void CheckList()
    {
        counWork = work.workInt - 1;

        if (noteCount == counWork)
        {
            linesContainer.SetActive(true);

            if (check == 1)
            {
                lines[0].SetActive(true);
            }
            if (check == 2)
            {
                lines[1].SetActive(true);
            }
            if (check == 3)
            {
                lines[2].SetActive(true);
            }
            if (check == 4)
            {
                lines[3].SetActive(true);
            }
            if (check == 5)
            {
                lines[4].SetActive(true);
            }
            if (check == 6)
            {
                lines[5].SetActive(true);
            }
            if (check == 7)
            {
                lines[6].SetActive(true);
            }
        }
        else
        {
            linesContainer.SetActive(false);
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
