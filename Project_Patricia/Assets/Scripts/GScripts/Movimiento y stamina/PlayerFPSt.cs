using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerFPSt : MonoBehaviour
{
    public CharacterController player;

    //public float speed = 10f;

    public float gravity;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public Slider staminaBar;

    private float maxStamina = 50;
    private float currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    [SerializeField] private float speedNormal;
    [SerializeField] private float speedMax, speed, speedLess;
    [SerializeField] private bool run, shift, crounch;
    

    [Header("Energy")]
    [SerializeField] private float energy = 10;
    [SerializeField] private float energyMax = 10;
    [SerializeField] private Image energyBar;
    [SerializeField] private float time, maxTime, timeRege, maxRege;

    [Header("Colliders")]
    public GameObject[] coll;

    public PlayerCrouch crouch;

    // Start is called before the first frame update
    void Start()
    {
        /*currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;*/
    }

    // Update is called once per frame
    void Update()
    {
        /*isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        player.Move(move * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (currentStamina > 0)
            {
                speed = 20f;
                UseStamina(1);
            }
            else
            {
                speed = 10f;
            }

        }
        else 
        {
            speed = 10f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        player.Move(velocity * Time.deltaTime);*/

        Move();
        Running();
        LessSpeed();
    }

    public void Move()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if(x!=0 || z!=0)
        {
            player.Move(move * speed * Time.deltaTime);
            run = true;
        }
        else
        {
            run = false;
        }

        if (run && shift)
        {
            coll[0].SetActive(true);
            coll[1].SetActive(true);
            coll[2].SetActive(true);
        }
        else if (run)
        {
            coll[0].SetActive(true);
            coll[1].SetActive(true);
            coll[2].SetActive(false);
        }
        if (run && crounch)
        {
            Debug.Log("Agachado Move");
            coll[0].SetActive(true);
            coll[1].SetActive(false);
            coll[2].SetActive(false);
        }
        else if (!run)
        {
            coll[0].SetActive(false);
            coll[1].SetActive(false);
            coll[2].SetActive(false);
        }



        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        player.Move(velocity * Time.deltaTime);
    }

    public void Running()
    {
        // Cambia a velocidad de correr
        if (Input.GetKeyDown(KeyCode.LeftShift) && energy >= 0)
        {
            speed = speedMax;
            shift = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || energy <= 0)
        {
            speed = speedNormal;
            shift = false;
        }
    }

    public void LessSpeed()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || crouch.crouch)
        {
            speed = speedLess;
            crounch = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) || !crouch.crouch)
        {
            speed = speedNormal;
            crounch = false;
        }
    }

    public void UseStamina(float amount)
    {
        if (currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;

            if (regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }
        else
        {
            Debug.Log("Not enough stamina");

        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while (currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 50;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }
        regen = null;
    }
}
