using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [SerializeField] private bool into;
    public bool canRifle;
    [SerializeField] private GameObject text, capsuleBlack;
    [SerializeField] private Collider col;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Inventary inve;
    [SerializeField] private Animator door;

    private void Update()
    {
        InpuRifle();
    }

    public void InpuRifle()
    {
        if (into && Input.GetKeyDown(KeyCode.E))
        {
            capsuleBlack.SetActive(true);
            inve.rifle= true;
            col.enabled= false;
            text.SetActive(false);
            canRifle = true;
            weapon.shootTwo= true;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(true);
            into = true;
            door.SetBool("On",false);            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(false);
            into = true;
        }
    }
}
