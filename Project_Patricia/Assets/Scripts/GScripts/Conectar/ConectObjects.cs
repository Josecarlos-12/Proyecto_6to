using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConectObjects : MonoBehaviour
{
    public GameObject connectedObject;
    public bool isConnected = false;
    public float breakForce = Mathf.Infinity;

    private FixedJoint joint;

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
        if (collision.gameObject == connectedObject)
        {
            isConnected = true;
            joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = connectedObject.GetComponent<Rigidbody>();
            joint.breakForce = breakForce;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == connectedObject && isConnected && joint != null)
        {
            isConnected = false;
            //Destroy(joint);
            joint = null;
        }
    }
}
