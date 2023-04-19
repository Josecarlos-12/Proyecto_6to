using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : MonoBehaviour
{
    public float speedH, speedV;
    float moveH, moveV;
    public PlayerInteraction interaction;
    public Transform obj, point;

    private void Start()
    {
        obj = GetComponent<Transform>();
    }

    private void Update()
    {
        OnMouseDrag();        
    }

    public void OnMouseDrag()
    {
        if (!interaction.bObj)
        {
            moveH += speedH * Input.GetAxis("Mouse X");
            moveV -= speedV * Input.GetAxis("Mouse Y");

            if (Input.GetMouseButton(0) && Input.GetAxis("Mouse X") != 0 && Input.GetAxis("Mouse Y") != 0)
            {
                transform.eulerAngles = new Vector3(moveV, moveH, transform.position.y);
            }
        }
        
    }
}
