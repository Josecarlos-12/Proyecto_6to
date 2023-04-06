using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedRotate : MonoBehaviour
{
    public bool r;
    public bool player ,big, mediun;
    public FollowOppositeDirection follow;
    public GameObject me, bi;

    public enum Hands
    {
        right, left
    }
    public Hands hands;

    private void Update()
    {

        if (mediun || big)
        {
            r = true;
        }
        else if(!mediun)
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
