using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotesUI : MonoBehaviour
{
    public GameObject note;
    public TextMeshProUGUI text;
    public Image imageNote;
    public bool bNote, intoNote;
    public List<Sprite> sNote = new List<Sprite>();
    public Sprite save;
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

    [Header("Call Other Script")]
    [SerializeField] PlayerFPSt player;
    [SerializeField] PlayerCrouch crouch;
    [SerializeField] CameraLook cam;

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
                break;
        }
        
    }

    private void Update()
    {
        Note();        
        CheckList();
        InputMouse();
    }

    public void Note()
    {
        if(Input.GetKeyDown(KeyCode.N) && !pause.isPaused)
        {
            bNote = !bNote;

            if (bNote)
            {
                cam.moveCamera = false;
                player.canWalk= false;
                crouch.crouchCan = false;
                note.SetActive(true);
                shoot = false;               
            }
            if(!bNote)
            {
                cam.moveCamera = true;
                player.canWalk = true;
                crouch.crouchCan = true;
                note.SetActive(false);
                shoot = true;
            }                       
        }

        if(sNote.Count == 0)
        {
            //imageNote.sprite= null;
        }
        else if (sNote.Count !=0) 
        {
        imageNote.sprite = sNote[noteCount];
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

    public void InputMouse()
    {
        if(Input.GetAxisRaw("Mouse ScrollWheel") > 0 && !shoot)
        {
            if (noteCount < sNote.Count - 1)
            {
                noteCount++;
            }
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0 && !shoot)
        {
            if (noteCount > 0)
            {
                noteCount--;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Note"))
        {
            intoNote = true;
            save = other.GetComponent<NoteInteraction>().image;
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
