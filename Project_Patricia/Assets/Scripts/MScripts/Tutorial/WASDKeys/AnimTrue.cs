using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTrue : MonoBehaviour
{
    public bool finish, init;

    public void Crouch()
    {
        init = true;
    }

    public void True()
    {
        finish = true;
    }
}
