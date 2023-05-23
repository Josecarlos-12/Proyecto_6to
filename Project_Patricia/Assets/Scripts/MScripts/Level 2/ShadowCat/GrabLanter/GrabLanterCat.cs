using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabLanterCat : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject lanter, lanterPlayer;
    [SerializeField] private Animator animLanter;
    [SerializeField] private bool into;
    [SerializeField] private Collider col;


    void Update()
    {
        InputLanter();
    }

    public void InputLanter()
    {
        if (into && Input.GetKeyDown(KeyCode.E))
        {
            animLanter.enabled = true;
            lanterPlayer.SetActive(true);
            text.SetActive(false);
            into = false;
            col.enabled= false;
            Destroy(lanter);
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
