using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsBossLevel3 : MonoBehaviour
{
    [SerializeField] private Animator animMike;

    public void ShootFalse()
    {
        animMike.SetBool("Shoot", false);
    }
}
