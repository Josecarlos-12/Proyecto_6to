using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrongBox : MonoBehaviour
{
    [SerializeField] private Collider col;
    [SerializeField] private GameObject text, note;
    [SerializeField] private Text pasword;
    [SerializeField] private bool into;
    [SerializeField] private Animator anim;
    public bool pass;
    [SerializeField] NotesUI noteUI;

    [Header("Shiny")]
    [SerializeField] int count;
    [SerializeField] Animator animKeyPad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E) && note==null)
        {
            into = false;
            pass = true;
            pasword.text = "2604";
            text.SetActive(false);
            col.enabled = false;
            anim.SetBool("Close", true);
            animKeyPad.SetBool("On", false);
            noteUI.check = 7;
        }
        if(note==null)
        {
            if(count<3)
            count++;

            if (count == 1)
            {
                animKeyPad.SetBool("On", true);
            }            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(note==null)
            {
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
