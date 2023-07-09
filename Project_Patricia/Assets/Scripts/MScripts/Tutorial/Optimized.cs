using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optimized : MonoBehaviour
{
    public GameObject[] threes;

    private void Start()
    {
        for (int i = 0; i < threes.Length; i++)
        {
            threes[i].SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < threes.Length; i++)
            {
                threes[i].SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < threes.Length; i++)
            {
                threes[i].SetActive(false);
            }
        }
    }
}
