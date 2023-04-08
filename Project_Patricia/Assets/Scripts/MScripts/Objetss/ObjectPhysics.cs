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
            //rbd.AddForce(new Vector3(other.gameObject.transform.position.x - transform.position.x, other.gameObject.transform.position.y - transform.position.y, other.gameObject.transform.position.z - transform.position.z).normalized * force, ForceMode.Impulse);            
            //rbd.AddForce(new Vector3( transform.position.x - other.gameObject.transform.position.x , transform.position.z - transform.position.y - other.gameObject.transform.position.y, other.gameObject.transform.position.z).normalized * force, ForceMode.Impulse);
    
                // Aplicar una fuerza hacia atrás
                Vector3 direccion = other.transform.position - transform.position;
                direccion = direccion.normalized;
                rbd.AddForce(direccion * force, ForceMode.Impulse);
            
        }
    }
}
