using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPlayMusic : MonoBehaviour
{
    [SerializeField] bool into;
    [SerializeField] GameObject text;
    [SerializeField] Animator handle;
    [SerializeField] Collider col;
    [SerializeField] BoxMusicInteractions box;
    public bool animBox;

    void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E))
        {
            animBox = true;
            box.Dream();
            col.enabled = false;
            text.SetActive(false);
            into = false;
            handle.SetBool("Handle", true);
            box.audi.Play();
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
