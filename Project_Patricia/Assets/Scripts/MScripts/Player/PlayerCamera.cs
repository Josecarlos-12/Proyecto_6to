using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public bool moveCamera = false;
    [SerializeField] private Transform playerBody;
    [SerializeField] private Transform cam;
    [SerializeField] private float mouseSensitivity = 80f;
    private float xRotation = 0;
    [SerializeField] private float positiveX= 90, negativeX=-90;

    private IEnumerator Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        yield return new WaitForSeconds(1);
        moveCamera = true;
    }

    void Update()
    {
        MoveCamera();
    }

    public void MoveCamera()
    {
        if (moveCamera)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, negativeX, positiveX);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
