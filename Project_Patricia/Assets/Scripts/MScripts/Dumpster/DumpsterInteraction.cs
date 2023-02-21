using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpsterInteraction : MonoBehaviour
{
    public bool open;
    [SerializeField] Animator anim;
    [SerializeField] PickableObject pick, pick2;
    [SerializeField] TrashOn trashOne, trashTwo;
    public NotesUI note;
    [SerializeField] private int count;
    public enum Work
    {
        tras, shopping
    }
    public Work word;

    private void Start()
    {
        open = true;
    }

    void Update()
    {
        if(trashOne.into && trashTwo.into)
        {
            if(count<3)
            count++;

            if (count == 1)
            {
                switch (word)
                {
                    case Work.tras:
                        note.check = 1;
                        anim.SetBool("Open", true);
                        break;
                    case Work.shopping:
                        note.check = 2;
                        break;
                }
            }                      
        }
    }
}
