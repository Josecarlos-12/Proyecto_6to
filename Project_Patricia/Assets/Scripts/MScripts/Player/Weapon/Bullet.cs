using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Renderer render;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject bulletHole;

    [Header("Raycast")]
    [SerializeField] private float distance;
    [SerializeField] private RaycastHit hit;

    public int damageAmount = 1;

    private void Start()
    {
        render = GetComponent<Renderer>();
        render.material.color = Color.blue;

        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
        Destroy(gameObject, 8);
    }

    private void Update()
    {
        Detected();
    }

    public void Detected()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hit, distance))
        {
            if (hit.transform.CompareTag("ObjStop"))
            {
                GameObject obj = Instantiate(bulletHole, hit.point, Quaternion.LookRotation(hit.normal));
                obj.transform.position += obj.transform.forward / 1000;
                Destroy(gameObject);
            }
                
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * distance);
    }

    private void OnTriggerEnter(Collider other)
    {
       

         if(other.CompareTag("Emilio") ) 
        {
            //other.GetComponent<EmilioHealth>().TakeDamage(damageAmount);
           // Destroy(this.gameObject);
        }
    }
}
