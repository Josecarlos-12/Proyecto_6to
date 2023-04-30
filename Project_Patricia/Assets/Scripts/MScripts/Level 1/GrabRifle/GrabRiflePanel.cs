using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRiflePanel : MonoBehaviour
{
    [SerializeField] GrabRifleSounds grab;
    [SerializeField] bool into;
    [SerializeField] GameObject textE, panel;
    [SerializeField] Collider thisColl, otherCollider;

    void Start()
    {
        
    }


    void Update()
    {
        if(into && grab.grab && Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            panel.SetActive(true);
            into = false;
            thisColl.enabled= false;
            textE.SetActive(false);
        }
    }

    public void Accept()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        panel.SetActive(false);
        otherCollider.enabled = true;
        this.gameObject.GetComponent<GrabRiflePanel>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (grab.grab)
            {
                textE.SetActive(true);
                into = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textE.SetActive(false);
            into = false;
        }
    }
}
