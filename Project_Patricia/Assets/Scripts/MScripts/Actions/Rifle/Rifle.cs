using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [SerializeField] private bool into;
    public bool canRifle;
    [SerializeField] private GameObject text;
    [SerializeField] private Collider col;
    [SerializeField] private Weapon weapon;

    private void Update()
    {
        InpuRifle();
    }

    public void InpuRifle()
    {
        if (into && Input.GetKeyDown(KeyCode.E))
        {
            col.enabled= false;
            text.SetActive(false);
            canRifle = true;
            weapon.shootTwo= true;
            Destroy(gameObject);
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
            into = true;
        }
    }
}
