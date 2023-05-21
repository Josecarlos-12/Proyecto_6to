using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    [SerializeField] private CharacterController character;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            character.stepOffset = 2f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            character.stepOffset = 0.9f;
        }
    }
}
