using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShinyLevel2Best : MonoBehaviour
{
    [SerializeField] private PickableObject pick;
    [SerializeField] Animator anim;
    [SerializeField] bool into;
    [SerializeField] TasksUILevel2 task;
    [SerializeField] int count;

    [SerializeField] private GameObject repeat;
    [SerializeField] private RepeatText repeatText;

    private void Update()
    {
        if (!pick.isPickable)
        {
            //anim.SetBool("On", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ShinyObjects"))
        {
            if (pick.isPickable)
            {
                anim.SetBool("On", true);

                if (task != null)
                {
                    if(count<3)
                    count++;

                    if (count == 1)
                    {
                        task.taskCount = 2;
                        repeat.SetActive(false);
                        repeatText.texContainer.SetActive(false);
                    }

                    
                }
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
