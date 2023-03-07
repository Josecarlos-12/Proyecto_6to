using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanterGrab : MonoBehaviour
{
    [SerializeField] private GameObject text, lanter;
    [SerializeField] private bool into;
    [SerializeField] private Collider col;

    private void Update()
    {
        Press();
    }

    public void Press()
    {
        if (into && Input.GetKeyDown(KeyCode.E))
        {
            lanter.SetActive(true);
            col.enabled = false;
            text.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(true);
            into= true;
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
