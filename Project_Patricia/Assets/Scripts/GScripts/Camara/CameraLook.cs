using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public bool moveCamera = false;
    public float mouseSensitivity = 80f;
    public Transform playerBody;
    float xRotation = 0;

    private IEnumerator Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        yield return new WaitForSeconds(0);
        moveCamera = true;
    }


    void Update()
    {
        if (moveCamera)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -80f, 80);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            playerBody.Rotate(Vector3.up * mouseX);
        }            
    }
}
