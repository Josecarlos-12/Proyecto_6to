using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float speedNormal;
    [SerializeField] private float speedMax, speed, speedCrouch;
    public Rigidbody rb;
    private Vector3 movementVector = Vector3.zero;
    [SerializeField] private bool run, shift;

    [Header("Energy")]
    [SerializeField] private float energy = 10;
    [SerializeField] private float energyMax = 10;
    [SerializeField] private Image energyBar;
    [SerializeField] private float time, maxTime, timeRege, maxRege;

    [Header("Raycast")]
    [SerializeField] private float distance;
    [SerializeField] private float radius;
    [SerializeField] private RaycastHit hit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = speedNormal;
    }

    private void Update()
    {
        GizmosRun();
        Move();
        Running();
        //ReductionEnergy();
        //UpdateEnergy();
    }

    public void UpdateEnergy()
    {
        energyBar.fillAmount = energy / energyMax;
    }

    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 velocity = Vector3.zero;

        if (horizontal != 0 || vertical != 0)
        {
            movementVector = (transform.forward * vertical + transform.right * horizontal).normalized;
            velocity = movementVector * speed;
            run = true;
        }
        else
        {
            run = false;
        }               

        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }

    public void ReductionEnergy()
    {
        if (run && shift && energy > 0)
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
            if(energy < energyMax)
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

    public void GizmosRun()
    {
        /*if(Physics.SphereCast(transform.position, transform.forward, out hit, distance))
        {
            if (hit.transform.CompareTag("ObjStop"))
            {
                Debug.Log("Toco");
            }
        }*/
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distance);
    }
}
