using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShinyObjects : MonoBehaviour
{
    [SerializeField] private NoteInteraction note;
    [SerializeField] Animator anim;
    [SerializeField] PickableObject pick;
    [SerializeField] GameObject clouth;
    [SerializeField] bool into;
    [SerializeField] Collider col;
    [SerializeField] BoxMusic boxMusic;
    [SerializeField] StrongBox strong;
    [SerializeField] PanelPills pPills;
    [SerializeField] AlarmOff alarm;
    [SerializeField] enum ObjectGames
    {
        Grab, Interaction, iron, box, pills, alarm
    }
    [SerializeField] ObjectGames objGames;


    private void Update()
    {
        switch (objGames)
        {
            case ObjectGames.iron:
                if(clouth!=null)
                {
                    if (clouth.activeInHierarchy && into)
                    {
                        anim.SetBool("On", true);
                    }
                    if (!clouth.activeInHierarchy && into)
                    {
                        col.enabled= false;
                        into= false;
                        anim.SetBool("On", false);
                    }
                }    
                if(clouth==null && into)
                {
                    col.enabled = false;
                    into = false;
                    anim.SetBool("On", false);
                }
                break;
            case ObjectGames.Grab:
                if (!pick.isPickable)
                {
                    anim.SetBool("On", false);
                }
                break;
            case ObjectGames.box:
                if (boxMusic.bBox)
                {
                   col.enabled = false;
                    anim.SetBool("On", false);
                    this.gameObject.GetComponent<ShinyObjects>().enabled= false;
                }
                break;
                case ObjectGames.pills:
                if(pPills.bPills)
                {
                    col.enabled = false;
                    anim.SetBool("On", false);
                    this.gameObject.GetComponent<ShinyObjects>().enabled = false;
                }
                break;
            case ObjectGames.alarm:
                if (alarm.offAlarm)
                {
                    col.enabled = false;
                    anim.SetBool("On", false);
                    this.gameObject.GetComponent<ShinyObjects>().enabled = false;
                }
                break;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ShinyObjects"))
        {
            switch (objGames)
            {
                case ObjectGames.Grab:
                    if (note.grabNote && pick.isPickable)
                    {
                        anim.SetBool("On", true);
                    }
                    break;

                case ObjectGames.Interaction:
                    if (note.grabNote)
                    {
                        anim.SetBool("On", true);
                    }
                    break;

                case ObjectGames.iron:
                    if (note.grabNote )
                    {
                        into = true;                                           
                    }
                    break;
                case ObjectGames.box:
                    if(strong.pass && !boxMusic.bBox)
                    {
                      anim.SetBool("On", true);                   
                    }
                    break;
                case ObjectGames.pills:
                    if (!pPills.bPills)
                    {
                        anim.SetBool("On", true);
                    }
                    break;
                case ObjectGames.alarm:
                    if (pPills.bPills && !alarm.offAlarm)
                    {
                        anim.SetBool("On", true);
                    }
                    break;
            }
                           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ShinyObjects"))
        {
            anim.SetBool("On", false);
            into = false;
        }
    }
}
