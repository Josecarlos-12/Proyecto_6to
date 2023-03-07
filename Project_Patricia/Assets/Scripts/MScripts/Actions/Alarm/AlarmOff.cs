using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmOff : MonoBehaviour
{
    [SerializeField] private AudioSource alarm;
    [SerializeField] private bool into;
    [SerializeField] private BoxMusicInteractions box;
    [SerializeField] private GameObject text;
    [SerializeField] private Collider col;



    void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E) && box.bAlarm==true)
        {
            into = false;
            col.enabled = false;
            alarm.Pause();
            col.enabled= false;
            text.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (box.bAlarm == true)
            {
                into = true;
                text.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = false;
            text.SetActive(false);
        }
    }
}
