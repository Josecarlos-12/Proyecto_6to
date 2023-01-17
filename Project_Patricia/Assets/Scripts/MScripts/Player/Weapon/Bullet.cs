using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Renderer render;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        render = GetComponent<Renderer>();
        render.material.color = Color.blue;

        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
        Destroy(gameObject, 4);
    }
}
