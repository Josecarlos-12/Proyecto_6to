using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ShinyObjects : MonoBehaviour
{
    [SerializeField] private InteracionKeys note;
    [SerializeField] Animator anim;
    [SerializeField] PickableObject pick;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ShinyObjects"))
        {
            if (note.grabNote && pick.isPickable)
            {
                anim.SetBool("On", true);
            }                
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ShinyObjects"))
        {
            anim.SetBool("On", false);
        }
    }
}
