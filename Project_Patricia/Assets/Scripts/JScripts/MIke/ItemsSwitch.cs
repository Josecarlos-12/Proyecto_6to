using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSwitch : MonoBehaviour
{
    public GameObject object01;
    public GameObject object02;

    // Start is called before the first frame update
    void Start()
    {
        object01.SetActive(false);
        object02.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("1"))
        {
            object01.SetActive(false);
            object02.SetActive(false);
        }

        if ( Input.GetButtonDown("2") )
        {
            object01.SetActive(true);
            object02.SetActive(false);
        }
        if ( Input.GetButtonDown("3") )
        {
            object01.SetActive(false);
            object02.SetActive(true);
        }
    }
}
