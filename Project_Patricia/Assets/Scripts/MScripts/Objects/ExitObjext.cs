using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitObjext : MonoBehaviour
{
    public GameObject obj;

    public void Off()
    {
        obj.SetActive(false);
    }
}
