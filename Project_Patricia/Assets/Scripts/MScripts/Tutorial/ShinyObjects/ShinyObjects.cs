using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ShinyObjects : MonoBehaviour
{
    [SerializeField] private InteracionKeys note;
    [SerializeField] Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ShinyObjects"))
        {
            if (note.grabNote)
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
