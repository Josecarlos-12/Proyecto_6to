using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float sensitivity;
    private Vector3 mouseReference;
    private Vector3 mouseOffset;
    private Vector3 rotation;
    private bool isRotating;
    public Camera cam;

    void Start()
    {
        sensitivity = 0.4f;
        rotation = Vector3.zero;
    }

    void LateUpdate()
    {
        if (isRotating)
        {
            mouseOffset = (Input.mousePosition - mouseReference);
            rotation.y = -(mouseOffset.x) * sensitivity;
            rotation.x = (mouseOffset.y) * sensitivity;
            Debug.Log(transform.parent.eulerAngles);
            transform.parent.eulerAngles += rotation;
            mouseReference = Input.mousePosition;

            Vector3 eulerAngles = transform.eulerAngles;
            transform.parent.eulerAngles = Vector3.zero;
            transform.eulerAngles = eulerAngles;
        }
    }

    void OnMouseDown()
    {
        isRotating = true;
        mouseReference = Input.mousePosition;
    }

    void OnMouseUp()
    {
        isRotating = false;
    }
}
