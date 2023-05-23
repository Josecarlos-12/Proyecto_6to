using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusesInteraction : MonoBehaviour
{
    [SerializeField] private Animator animCam;
    [SerializeField] private GameObject cam, prota, text;
    [SerializeField] private bool into;
    [SerializeField] private Collider col;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E))
        {
            into = false;
            col.enabled= false;
            text.SetActive(false);
            prota.SetActive(false);
            cam.SetActive(true);
            animCam.enabled= true;
            Cursor.visible=true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(true);
            into = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(false);
            into = false;
        }
    }
}
