using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawersOpen : MonoBehaviour
{
    public bool open;
    [SerializeField] private BoxPlayMusic on;
    [SerializeField] private Collider col, noteColl;
    [SerializeField] int count = 0;

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

    public void Close()
    {
        open= false;
    }
}
