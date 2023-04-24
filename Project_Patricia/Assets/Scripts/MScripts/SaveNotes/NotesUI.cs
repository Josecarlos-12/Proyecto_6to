using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotesUI : MonoBehaviour
{
    public GameObject note;
    public TextMeshProUGUI text;
    public bool bNote, intoNote;
    [TextArea(4, 4)]
    public List<string> sNote = new List<string>();
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
    public bool one, two, three, four, five, six, seven, eight, nine;

    public enum WorkStar
    {
        None, WorkNumber
    }
    public WorkStar workS;

    private void Start()
    {
        shoot = true;

        switch (workS)
        {
            case WorkStar.None:
            break; 
            case WorkStar.WorkNumber:
                work.workInt = 1;
                lines[0].SetActive(true);
                lines[1].SetActive(true);
                lines[2].SetActive(true);
                lines[3].SetActive(true);
                lines[4].SetActive(true);
                lines[5].SetActive(true);
                lines[6].SetActive(true);
                break;
        }
        
    }

    private void Update()
    {
        Note();
        
        CheckList();
    }

    public void Note()
    {
        if(Input.GetKeyDown(KeyCode.N) && !pause.isPaused)
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
                one = true;
                lines[0].SetActive(true);
            }
            if (check == 2)
            {
                two = true;
                lines[1].SetActive(true);
            }
            if (check == 3)
            {
                three=true;
                lines[2].SetActive(true);
            }
            if (check == 4)
            {
                four=true;
                lines[3].SetActive(true);
            }
            if (check == 5)
            {
                five=true;
                lines[4].SetActive(true);
            }
            if (check == 6)
            {
                six=true;
                lines[5].SetActive(true);
            }
            if (check == 7)
            {
                seven=true;
                lines[6].SetActive(true);
            }
            if (check == 8)
            {
                eight = true;
                lines[6].SetActive(true);
            }
            if (check == 9)
            {
                nine = true;
                lines[8].SetActive(true);
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
