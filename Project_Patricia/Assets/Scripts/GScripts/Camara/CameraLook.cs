using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public bool moveCamera = false;
    public float mouseSensitivity = 80f;
    public Transform playerBody;
    public float xRotation = 0;

    public Sensibility sen;


    private IEnumerator Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        yield return new WaitForSeconds(0.3f);
        moveCamera = true;
    }


    void Update()
    {
        if (moveCamera)
        {
            mouseSensitivity = sen.sensibility.value * 40;

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -80f, 80);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            playerBody.Rotate(Vector3.up * mouseX);
        }            
    }
}
