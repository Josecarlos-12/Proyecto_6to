using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchCharlie : MonoBehaviour
{
    [SerializeField] private GameObject punch;
    public bool touch;

    public void Puch()
    {
        punch.SetActive(true);
    }

    public void PunchFalse()
    {
        punch.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HealthMike"))
        {
            //punch.SetActive(false);
            touch = true;
            print("Pego");
        }
    }
}
