using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPopUp : MonoBehaviour
{

    public float speedRotation = 100.0f;
    bool dragging = false;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
    }
    private void OnMouseDrag()
    {
        dragging = true;
    }
    private void FixedUpdate()
    {
        if (dragging)
        {
            float x = Input.GetAxis("Mouse X") * speedRotation * Time.fixedDeltaTime;
            float y = Input.GetAxis("Mouse Y") * speedRotation * Time.fixedDeltaTime;

            rb.AddTorque(Vector3.down * x);
            rb.AddTorque(Vector3.right * y);
        }
    }
}
