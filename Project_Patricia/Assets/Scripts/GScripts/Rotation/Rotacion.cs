using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Rotacion : MonoBehaviour
{

    public bool rotation, rot;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotation && Input.GetKeyDown(KeyCode.E))
        {
            rot = true;
            
        }
        else if (Input.GetKeyUp(KeyCode.E) ||  !rotation)
        {
            rot = false;    
        }

        if(rot)
        {
            transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime) );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag ("Player"))
        {
            Debug.Log("Player");
            rotation = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            rotation = false;
        }
    }
}
