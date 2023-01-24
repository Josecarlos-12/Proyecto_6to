using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarma : MonoBehaviour
{
    public GameObject GO_Alarma;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GO_Alarma.SetActive(true);
        }
    }
    void Animar()
    {
        GO_Alarma.SetActive(true);
    }
    void DesActive()
    {
        GO_Alarma.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
