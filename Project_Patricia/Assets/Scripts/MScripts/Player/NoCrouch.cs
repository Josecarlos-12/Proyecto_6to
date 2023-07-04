using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class NoCrouch : MonoBehaviour
{
    [SerializeField] private bool into;
    [SerializeField] private PlayerCrouch crouch;

    private void Update()
    {
        if (into)
        {
            crouch.crouchCan = false;
            crouch.press = false;
        }
        else
        {
            crouch.crouchCan = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            into = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            into = false;
        }
    }
}
