using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DetectedRotate : MonoBehaviour
{
    public bool r;
    public bool player ,big, mediun, desBig;
    public FollowOppositeDirection follow;
    public GameObject me, bi;

    public enum Hands
    {
        right, left
    }
    public Hands hands;

    private void Update()
    {
        if (big)
        {
            desBig = true;
        }
        else
        {
            desBig = false;
        }

        if (mediun)
        {
            r = true;
        }
        else
        {
            r = false;
        }

        if(me!= null)
        {
            if (!me.activeInHierarchy)
            {
                mediun= false;
            }
        }

        if (bi != null)
        {
            if (!bi.activeInHierarchy)
            {
                big = false;
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
            me=other.gameObject;
            mediun= true;
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
