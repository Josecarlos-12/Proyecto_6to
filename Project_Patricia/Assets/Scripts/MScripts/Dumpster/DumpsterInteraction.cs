using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpsterInteraction : MonoBehaviour
{
    public bool into, open;
    [SerializeField] Animator anim;
    [SerializeField] PickableObject pick, pick2;
    [SerializeField] TrashOn trashOne, trashTwo;
    public NotesUI note;

    void Update()
    {
        if(trashOne.into && trashTwo.into)
        {
            note.check = 1;
            anim.SetBool("Open", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = false;
        }
    }
}
