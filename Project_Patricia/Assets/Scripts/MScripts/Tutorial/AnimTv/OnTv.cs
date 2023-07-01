using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTv : MonoBehaviour
{
    [SerializeField] private GameObject eText, cam, prota, ui;
    [SerializeField] private bool into, into2;
    [SerializeField] private Animator anim;

    private void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E))
        {
            ui.SetActive(false);
            anim.enabled= true;
            eText.SetActive(false);
            into = false;
            prota.SetActive(false);
            cam.SetActive(true);
            StartCoroutine("PressE");
        }

        if (into2 && Input.GetKeyDown(KeyCode.E))
        {
            enabled= false;
            ui.SetActive(true);
            prota.SetActive(true);
            cam.SetActive(false);
        }
    }

    public IEnumerator PressE()
    {
        yield return new WaitForSeconds(1);
        into2 = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            eText.SetActive(true);
            into = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            eText.SetActive(false);
            into = false;
        }
    }
}
