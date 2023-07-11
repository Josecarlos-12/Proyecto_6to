using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBoss : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    public LayerMask collisionLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name== "Health")
        {
            Destroy(gameObject);
        }

        if (collisionLayer == (collisionLayer | (1 << other.gameObject.layer)))
        {
            Destroy(gameObject);
        }
    }
}
