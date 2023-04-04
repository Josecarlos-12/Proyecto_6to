using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLeft : MonoBehaviour
{
    public bool l;
    public bool player, big, mediun;
    public FollowOppositeDirection follow;
    public GameObject me, bi;


    private void Update()
    {
        if (bi != null)
        {
            if (!bi.activeInHierarchy)
            {
                big = false;
            }

        }

       
        if (mediun || big)
        {
            l = true;
        }
        else if (!mediun && !big)
        {
           // l = false;
        }

        if (me != null)
        {
            if (!me.activeInHierarchy)
            {
                mediun = false;
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = true;

        }

        if (other.gameObject.name == "Big")
        {
            bi = other.gameObject;
            big = true;
        }
        if (other.gameObject.name == "Mediun")
        {
            me = other.gameObject;
            mediun = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = true;
        }

        if (other.gameObject.name == "Big")
        {
            big = false;
        }
        if (other.gameObject.name == "Mediun")
        {
            mediun = false;
        }
    }
}
