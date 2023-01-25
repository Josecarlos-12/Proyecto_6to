using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Rotacion : MonoBehaviour
{

    public bool rotation;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rotation=true && Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0,0,speed), Time.deltaTime);
        }
    }

    public void OntriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag ("Player"))
        {
            rotation = true;
        }
    }

    public void OntriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            rotation = false;
        }
    }
}
