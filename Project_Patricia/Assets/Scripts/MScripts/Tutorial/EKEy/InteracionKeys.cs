using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracionKeys : MonoBehaviour
{
    [SerializeField] GameObject interactionE, panel;
    [SerializeField] bool touch;
    [SerializeField] Collider coll, collOther;


    void Start()
    {
        
    }

    void Update()
    {
        if(touch && Input.GetKeyDown(KeyCode.E))
        {
            interactionE.SetActive(false);
            panel.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Accept()
    {
        touch= false;
        collOther.enabled = true;
        panel.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            touch= true;
            coll.enabled= false;
            interactionE.SetActive(true);
        }
    }
}
