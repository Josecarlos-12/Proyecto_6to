using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFist : MonoBehaviour
{
    private new Rigidbody rigidbody;

    [Header("Attributes Settings")]
    public float caminar;
    public float correr;
    public float agachado;
    float Speed;
    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public GameObject Cam;

    [Header("Buttom Settings")]
    public KeyCode adelante = KeyCode.W;
    public KeyCode atras = KeyCode.S;
    public KeyCode izquierda = KeyCode.A; 
    public KeyCode derecha = KeyCode.D;

    [Header("PlayerState")]
    public State state = State.idle;
    public Animator animator;

    float hor;
    float ver;

    bool crouch;

    public enum State
    {
        idle,walk,run
    }
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        state = State.idle;
    }
    void Update()
    {
        switch (state)
        {
            case State.idle:
                animator.SetBool("idle",true);
                animator.SetBool("walk", false);
                animator.SetBool("run", false);
                break;

            case State.walk:
                animator.SetBool("walk", true);
                animator.SetBool("idle", false);
                animator.SetBool("run", false);
                break;

            case State.run:
                animator.SetBool("run", true);
                animator.SetBool("walk", false);
                animator.SetBool("idle", false);
                break;
        }
        KeyDetect();
        Move();
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.V) && !Input.GetKey(KeyCode.LeftControl) && !crouch)
            Speed = correr;

        else if (state == State.idle && !crouch)
            Speed = caminar;

        Vector3 velocity = Vector3.zero;

        float targetAngle = (Mathf.Atan2(hor, ver) * Mathf.Rad2Deg) + Cam.transform.rotation.eulerAngles.y;

        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle , ref turnSmoothVelocity, turnSmoothTime);



        if (hor > 0 || ver > 0 || hor < 0 || ver < 0)
        {
            if(Speed == caminar)
                state = State.walk;

            else if (Speed == correr)
                state = State.run;

            else if (Speed == agachado)
                state = State.walk;
        }
        else
        {
            state = State.idle;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            crouch = true;
            animator.SetBool("crouch", true);
            Speed = agachado;
        }
        else if (Input.GetKeyUp(KeyCode.G))
        {
            crouch= false;
            animator.SetBool("crouch", false);
            Speed = caminar;
        }


        if (hor != 0 || ver != 0)
        {
            transform.rotation = Quaternion.Euler(0f, angle , 0f);

            Vector3 direction = (Cam.transform.forward * ver + Cam.transform.right * hor).normalized;
            velocity = direction * Speed;

            #region prueba
            //Vector3 direction = (transform.forward * ver + transform.right * hor).normalized;
            //velocity = direction * Speed;
            //direction.Normalize();
            #endregion
        }

        velocity.y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;
    }
    void KeyDetect()
    {
        if (Input.GetKey(adelante) && !Input.GetKey(atras))
            ver = 1;
        else if (Input.GetKey(atras) && !Input.GetKey(adelante))
            ver = -1;
        else
            ver = 0;

        if (Input.GetKey(derecha) && !Input.GetKey(izquierda))
            hor = 1;
        else if (Input.GetKey(izquierda) && !Input.GetKey(derecha))
            hor = -1;
        else
            hor = 0;
    }
}
