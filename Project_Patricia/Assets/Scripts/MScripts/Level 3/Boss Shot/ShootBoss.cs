using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBoss : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
        Destroy(gameObject, 8);
    }
}
