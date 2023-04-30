using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkZoneTutorial : MonoBehaviour
{
    [SerializeField] Collider thisColl, otherColl;
    [SerializeField] GameObject panel, textE;
    [SerializeField] bool into;

    void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E))
        {
            thisColl.enabled= false;
            textE.SetActive(false);
            into = false;
            panel.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void Accetp()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        otherColl.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = true;
            textE.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = false;
            textE.SetActive(false);
        }
    }
}
