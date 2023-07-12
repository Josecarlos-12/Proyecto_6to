using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrongBox : MonoBehaviour
{
    [SerializeField] private Collider col;
    [SerializeField] private GameObject text, note;
    [SerializeField] private Text pasword;
    [SerializeField] private bool into, off;
    [SerializeField] private Animator anim;
    public bool pass;
    [SerializeField] NotesUI noteUI;

    [Header("Shiny")]
    [SerializeField] int count;
    [SerializeField] Animator animKeyPad;

    [SerializeField] private GameObject taskUi;
    [SerializeField] private TasksUILevel2 task;
    [SerializeField] private GameObject player, cam;
    [SerializeField] private AudioClip clip;
    [SerializeField] private RepeatText repeatText;
    [SerializeField] private GameObject repeat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E) && note==null)
        {            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            into = false;
            pass = true;
            //pasword.text = "101203";
            text.SetActive(false);
            //col.enabled = false;            
            animKeyPad.SetBool("On", false);
            player.SetActive(false);
            cam.SetActive(true);
            StartCoroutine("OffNote");
        }
        if(note==null)
        {
            if(count<3)
            count++;

            if (count == 1)
            {
                repeatText.texContainer.SetActive(false);
                repeatText.audio.Stop();
                repeat.SetActive(false);
                repeat.SetActive(true);
                repeatText.clip = clip;
                repeatText.sText = "Mike Schmith: Fecha de nacimiento de Charlie, Fecha de nacimiento de Charlie";
                animKeyPad.SetBool("On", true);
            }            
        }

        if (off && Input.GetKeyDown(KeyCode.E) && note == null)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            player.SetActive(true);
            cam.SetActive(false);
        }
    }

    public IEnumerator OffNote()
    {
        yield return new WaitForSeconds(0.3f);
        off = true;
    }

    public void Next()
    {
        //task.go = true;
        //task.task = "Check the music box";
        //taskUi.SetActive(true);
        anim.SetBool("Close", true);
        noteUI.check = 7;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(note==null)
            {
                off = false;
                text.SetActive(true);
                into = true;
            }            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(false);
            into = false;
        }
    }
}
