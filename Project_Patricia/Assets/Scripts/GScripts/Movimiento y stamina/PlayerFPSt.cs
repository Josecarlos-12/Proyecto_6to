using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerFPSt : MonoBehaviour
{
    public CharacterController player;

    //public float speed = 10f;

    public float gravity;
    public float jumpHeight;
    public int i = 0;

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
    public bool run, shift, crounch, bEnergy;
    

    [Header("Energy")]
    [SerializeField] private float energy = 10;
    [SerializeField] private float energyMax = 10;
    [SerializeField] private Image energyBar;
    [SerializeField] private float time, maxTime, timeRege, maxRege;

    [Header("Colliders")]
    public GameObject[] coll;

    public PlayerCrouch crouch;

    public bool canRun;
    public bool canWalk;
    [SerializeField] private AudioSource audioBreathing;
    [SerializeField] private AudioSource audioWalking;
    [SerializeField] private AudioClip clipRun, clipWalk, clipForestWalk, clipForestRun;
    [SerializeField] private AudioClip clipsRun, clipsWalk;

    [Header("Layers")]
    [SerializeField] private LayerMask layer;
    [SerializeField] private float raycastDistance = 10f;


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
        //Running();
        Speed();
        UpdateEnergy();
        ReductionEnergy();

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, raycastDistance, layer))
        {
            if (hit.collider.CompareTag("Floor"))
            {
                clipsRun = clipRun;
                clipsWalk = clipWalk;
                print("Piso");

                if (Input.GetKeyDown(KeyCode.LeftShift) && bEnergy && canRun)
                {
                    audioWalking.clip = clipsRun;

                }
                else if (!shift && !crouch.crouch || !bEnergy)
                {
                    audioWalking.clip = clipsWalk;
                }

            }
            else if (hit.collider.CompareTag("Forest"))
            {
                clipsRun = clipForestRun;
                clipsWalk = clipForestWalk;
                print("Forest");
                if (shift && bEnergy && canRun)
                {
                    audioWalking.clip = clipsRun;

                }
                else if (!shift && !crouch.crouch || !bEnergy)
                {
                    audioWalking.clip = clipsWalk;
                }
            }
        }
    }

    public void UpdateEnergy()
    {
        energyBar.fillAmount = energy / energyMax;
    }

    public void ReductionEnergy()
    {
        if (run && shift && energy > 0 && canRun)
        {
            time += Time.deltaTime;

            if (time > maxTime)
            {
                StopCoroutine("Next");
                time = 0;
                energy -= 1;
            }
        }
        else if (!run || !shift)
        {
            if (energy < energyMax)
            {
                StartCoroutine("Next");
                if (timeRege > maxRege)
                {
                    timeRege = 0;
                    energy += 1;
                }
            }

        }
    }

    public IEnumerator Next()
    {
        yield return new WaitForSeconds(3);
        timeRege += Time.deltaTime;
    }

    public void Move()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            print("isgrounded");
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (canWalk)
        {
            if (x != 0 || z != 0)
            {
                
                player.Move(move.normalized * speed * Time.deltaTime);
                run = true;

                if (!audioWalking.isPlaying)
                {
                    audioWalking.Play();
                }
            }
            else
            {
                run = false;
                audioWalking.Stop();
            }
        }
        else
        {
            run = false;
        }

        if (run && shift && bEnergy)
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
        

    public void Speed()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && bEnergy && canRun)
        {
            audioWalking.clip = clipsRun;
            speed = speedMax;            

        }
        else if (crouch.crouch)
        {
            speed = speedLess;
            crounch = true;
        }
        else if(!shift && !crouch.crouch || !bEnergy)
        {
            audioWalking.clip = clipsWalk;
            speed = speedNormal;
            crounch = false;            
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shift = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            shift = false;
        }

        if(energy>=2)
        {
            i = 0;
            bEnergy = true;
        }
        if (energy <= 1)
        {
            
            i++;
            if (i < 3)
            {
                audioBreathing.Play();
                print("Agitado");
            }
            bEnergy= false;
            
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


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * raycastDistance);
    }
}
