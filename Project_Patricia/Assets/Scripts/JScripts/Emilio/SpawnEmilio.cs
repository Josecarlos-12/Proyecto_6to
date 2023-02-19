using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEmilio : MonoBehaviour
{
    public GameObject[] emilio;
    public GameObject[] emilioVarTransform;
    public GameObject emilioVar;
    public GameObject prefab;
    public enum Emilios { emilio1,emilio2 }
    public Emilios emilion;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.F) )
        {
            switch (emilion)
            {
                case Emilios.emilio1:
                    for (int i = 0; i < emilio.Length; i++)
                    {
                        Instantiate(prefab, emilio[i].transform.position, emilio[i].transform.rotation);
                    }
                    break;

                case Emilios.emilio2:
                    for (int i = 0; i < emilioVarTransform.Length; i++)
                    {
                        Instantiate(emilioVar, emilioVarTransform[i].transform.position, emilioVarTransform[i].transform.rotation);
                    }
                    break; 
            }
            
        }
    }

}
