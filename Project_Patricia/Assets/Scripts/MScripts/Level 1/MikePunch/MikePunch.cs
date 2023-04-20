using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikePunch : MonoBehaviour
{
    [SerializeField] private GameObject punchObject;
    public void PunchOn()
    {
        punchObject.SetActive(true);
    }

    public void PunchOff()
    {
        punchObject.SetActive(false);
    }
}
