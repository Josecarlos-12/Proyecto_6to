using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCatPunchLevel2 : MonoBehaviour
{
    [SerializeField] private GameObject punch;


    public void TouchPunch()
    {
        punch.SetActive(true);
    }

    public void FalsePunch()
    {
        punch.SetActive(false);
    }
}
