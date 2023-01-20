using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPhysics : MonoBehaviour
{
    [SerializeField] private Rigidbody rbd;
    [SerializeField] private float force;

    private void Start()
    {
        rbd = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BulletPlayer"))
        {
            rbd.AddForce(new Vector3(other.gameObject.transform.position.x - transform.position.x, 0, other.gameObject.transform.position.z - transform.position.z).normalized * force, ForceMode.Impulse);            
        }
    }
}
