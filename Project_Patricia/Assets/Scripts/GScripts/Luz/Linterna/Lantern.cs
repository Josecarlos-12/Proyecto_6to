using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lantern : MonoBehaviour
{
    public Light lightLantern;

    [Header("Energy")]
    public float actualEnergy = 100;
    public float maxEnergy = 100;
    public float comVelocity;
    public float recVelocity;


    [Header("Interfaz")]
    public Image batteryBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        if(Input.GetButtonDown("Lantern"))
        {

            if(lightLantern.enabled == true)
            {
                lightLantern.enabled = false;
            }
            else if (lightLantern.enabled == false && actualEnergy > 10)
            {
                lightLantern.enabled = true;
            }

        }

        if (lightLantern.enabled == true)
        {
            actualEnergy -= Time.deltaTime * comVelocity;
            lightLantern.intensity = Mathf.Lerp(0.5f, 4000f, actualEnergy / maxEnergy);

            if (actualEnergy <= 0)
            {
                actualEnergy = 0;
                lightLantern.enabled = false;
            }
        }
        else
        {
            actualEnergy += Time.deltaTime * recVelocity;

            if(actualEnergy > maxEnergy)
            {
                actualEnergy = maxEnergy;
            }
        }

        batteryBar.fillAmount = actualEnergy / maxEnergy;
    }
}
