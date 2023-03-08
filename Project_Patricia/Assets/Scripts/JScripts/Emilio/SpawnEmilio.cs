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
    public enum Emilios { emilio1, emilio2 }
    public Emilios emilion;

    [Header("OnlyOne")]
    [SerializeField] private GameObject emiOne;
    [SerializeField] private GameObject point;
    [SerializeField] private Rifle rifle;
    [SerializeField] private int one;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OnlyOne();
    }

    public void OnlyOne()
    {
        if (rifle.canRifle)
        {
            if(one<3)
            one++;

            if (one == 1)
            {
                StartCoroutine("Spawn");
            }
            
        }        
    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(5);
        Instantiate(emiOne, point.transform.position, point.transform.rotation);
    }

    public void VariousObjects()
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
