using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMS : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;
    public CharacterController player;
    public float playerSpeed = 10f;

    public Slider staminaBar;

    private float maxStamina = 50;
    private float currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static PlayerMS instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(currentStamina > 0)
            {
                playerSpeed = 20f;
                UseStamina(1);
            }
            else
            {
                playerSpeed = 10f;
            }

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

    private void FixedUpdate()
    {
        player.Move(new Vector3(horizontalMove, 0, verticalMove) * playerSpeed * Time.deltaTime);
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
