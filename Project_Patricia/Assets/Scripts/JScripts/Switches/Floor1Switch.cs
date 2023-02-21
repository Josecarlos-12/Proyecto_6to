using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SpawnEmilio;

public class Floor1Switch : MonoBehaviour
{
    public GameObject[] Lights;
    public GameObject text;
    public bool into;
    public bool on;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Inpt();
    }
    public void Inpt()
    {
        if (Input.GetKeyDown(KeyCode.E)&&into)
        {
            on = !on;
            if (on)
            {
                for (int i = 0; i < Lights.Length; i++)
                {
                    Lights[i].gameObject.SetActive(false);
                }
            }
            else
            {
                for (int i = 0; i < Lights.Length; i++)
                {
                    Lights[i].gameObject.SetActive(true);
                }
            }
            
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
