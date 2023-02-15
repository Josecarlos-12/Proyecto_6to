using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject lightObject;
    public bool luz;
    private bool lightOnOff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnOffLight()
    {
        lightOnOff = !lightOnOff;

        if(lightOnOff == true)
        {
            lightObject.SetActive(true);
        }
        else
        {
            lightObject.SetActive(false);
        }
    }
}
