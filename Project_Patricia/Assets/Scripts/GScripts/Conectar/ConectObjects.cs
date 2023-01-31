using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConectObjects : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == object2)
        {
            ConfigurableJoint joint = object1.AddComponent<ConfigurableJoint>();
            joint.connectedBody = object2.GetComponent<Rigidbody>();
        }
    }
}
