using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawersOpen : MonoBehaviour
{
    public bool open;
    [SerializeField] private BoxPlayMusic on;
    [SerializeField] private Collider col, noteColl;
    [SerializeField] private Animator anim;
    [SerializeField] int count = 0;
    [SerializeField] int count2 = 0;
    [SerializeField] GameObject[] pills;
    [SerializeField] bool bPill;


    private void Update()
    {
        if (pills.Length >= 3)
        {
            if (pills[0] == null && pills[1] == null && pills[2] == null && bPill)
            {
                if (count2 < 3)
                    count2++;

                if (count2 == 1)
                {
                    col.enabled = true;
                }
            }
        }
        
    }

    public void Open()
    {
        open = true;

        if (on != null)
        {
            if (on.on)
            {
                count++;
                if (count == 1)
                {
                    //col.enabled = false;
                    //noteColl.enabled = true;
                }
            }
        }
    }

    public void FalseMove()
    {
        if(pills.Length >= 3)
        {
            if (pills[0] != null && pills[1] != null && pills[2] != null)
            {
                col.enabled = false;
                bPill = true;
            }
        }
        
    }

    public void Close()
    {
        open= false;
    }
}
