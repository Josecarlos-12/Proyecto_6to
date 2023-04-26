using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    CharacterController ChCo;
    public float speed = 5;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    void Start()
    {
        ChCo = GetComponent<CharacterController>();
    }
    void Update()
    {
        PlayerMove();
    }
    void PlayerMove()
    {
        //Movimiento
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        ChCo.SimpleMove(new Vector3(x * speed, 0, z * speed));

        //Rotacion
        float targetAngle = Mathf.Atan2(x,z) * Mathf.Rad2Deg;

        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnSmoothVelocity,turnSmoothTime);

        if(x != 0 || z != 0)
        {
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }
}
