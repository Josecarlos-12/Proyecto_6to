using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float sensitivity;
    public Vector3 mouseReference;
    public Vector3 mouseOffset;
    public Vector3 rotation;
    public bool isRotating;
    public enum State
    {
        more, less, flash, rabbit
    }
    public State state;


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
            

            switch (state)
            {
                case State.more:
                    rotation.y = -(mouseOffset.x) * sensitivity;
                    rotation.z = (-mouseOffset.y) * sensitivity;
                    break;
                    
                case State.less:
                    rotation.y = -(mouseOffset.x) * sensitivity;
                    rotation.z = (mouseOffset.y) * sensitivity;
                    break;

                case State.flash:
                    rotation.y = -(mouseOffset.x) * sensitivity;
                    rotation.x = -(mouseOffset.y) * sensitivity;
                    break;

                case State.rabbit:
                    rotation.y = -(mouseOffset.x) * sensitivity;
                    rotation.x = (mouseOffset.y) * sensitivity;
                    break;
            }

            
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
