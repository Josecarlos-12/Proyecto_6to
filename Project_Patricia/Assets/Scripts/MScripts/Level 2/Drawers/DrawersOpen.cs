using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawersOpen : MonoBehaviour
{
    public bool open;

    public void Open()
    {
        open = true;
    }

    public void Close()
    {
        open= false;
    }
}
