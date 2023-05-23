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

    public float time, maxTime; 
    public float timeMore, maxTimeMore;


    [Header("Interfaz")]
    public Image batteryBar;

    public enum Lanter
    {
        god, bad
    }
    public Lanter lanter;

    void Update()
    {
        switch (lanter)
        {
            case Lanter.god:
                Normal();
                break;
            case Lanter.bad:
                Bad();
                break;
        }
        

       /* if (lightLantern.enabled == true)
        {
            StopCoroutine("LessEnergy");

            time = time + Time.deltaTime;

            if (time > maxTime)
            {
                time = 0;
                actualEnergy -= 25;
            }

            if (actualEnergy <= 0)
            {
                actualEnergy = 0;
                lightLantern.enabled = false;                
            }
        }
        else
        {
            StartCoroutine("LessEnergy");
        }*/
    }

    public void Normal()
    {
        if (Input.GetButtonDown("Lantern"))
        {

            if (lightLantern.enabled == true)
            {
                lightLantern.enabled = false;
            }
            else if (lightLantern.enabled == false)
            {
                lightLantern.enabled = true;
            }

        }
    }

    public void Bad()
    {
        print("Malogrado");
    }

    public IEnumerator LessEnergy()
    {
        yield return new WaitForSeconds(2);

        if(actualEnergy<maxEnergy)
        {
            timeMore += Time.deltaTime;
            if (timeMore > maxTimeMore)
            {
                timeMore = 0;
                actualEnergy += 25;
            }

            if (actualEnergy > maxEnergy)
            {
                actualEnergy = maxEnergy;
            }
        }
    }
}
