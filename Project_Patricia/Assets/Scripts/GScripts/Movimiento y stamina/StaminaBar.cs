using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public float stamina;
    float maxStamina;

    public Slider staminBar;
    public float dValue;
    // Start is called before the first frame update
    void Start()
    {
        maxStamina = stamina;
        staminBar.maxValue = maxStamina;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            DecreaseEnergy();
        }
        else if (stamina != maxStamina)
        {
            IncreaseEnergy();
        }

        staminBar.value = stamina;
    }

    private void DecreaseEnergy()
    {
        if (stamina != 0)
        {
            stamina -= dValue * Time.deltaTime;
        }
    }

    private void IncreaseEnergy()
    {
            stamina += dValue * Time.deltaTime;
    }
}
