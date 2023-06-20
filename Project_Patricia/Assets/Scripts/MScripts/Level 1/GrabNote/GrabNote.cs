using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabNote : MonoBehaviour
{
    [SerializeField] private NoteInteraction note;
    [SerializeField] private PickableObject[] pickableObject;
    [SerializeField] private TrashOn[] trashOn;
    [SerializeField] private int count;
    [SerializeField] private GrabNote grabNote;

    private void Update()
    {
        if (note.grabNote == true)
        {
            if(count<3)
            count++;

            if(count == 1)
            {
                for (int i = 0; i < pickableObject.Length; i++)
                {
                    pickableObject[i].enabled = true;
                    pickableObject[i].isPickable= true;
                }
                for (int i = 0; i < trashOn.Length; i++)
                {
                    trashOn[i].enabled = true;
                }
                grabNote.enabled = false;
            }

           
        }
    }



}
