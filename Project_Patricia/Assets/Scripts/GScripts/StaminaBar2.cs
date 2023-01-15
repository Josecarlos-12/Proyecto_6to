using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar2 : MonoBehaviour
{
    public Slider staminaBar;

    private int maxStamina = 50;
    private int currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static StaminaBar2 instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {



    }

    public void UseStamina(int amount)
    {
        if(currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;

            if(regen != null)
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

        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 50;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }
        regen = null;
    }
}
