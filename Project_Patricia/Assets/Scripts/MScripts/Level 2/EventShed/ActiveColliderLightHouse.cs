using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveColliderLightHouse : MonoBehaviour
{
    [SerializeField] private Collider col;

    public void Active()
    {
        col.enabled = true;
    }

    public void Desactive()
    {
        col.enabled = false;
    }
}
