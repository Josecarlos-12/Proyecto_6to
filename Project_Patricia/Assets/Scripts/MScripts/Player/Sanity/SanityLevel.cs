using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityLevel : MonoBehaviour
{
    public PlayerHealth health;
    public SleepMode sleep;

    public int sixty, forty, twenty, ten, good;
    public bool bGood, bloomInto, bloomFalse;

    public float targetIntensity = 0.7f;
    public float changeSpeed = 0.5f;

    public int run, crouch;

    [SerializeField] private GameObject gameOver, prota, cam;

    void Start()
    {
        
    }

    void Update()
    {
        PanelDmg();

      

        if(bGood && health.sanity > 60)
        {

            BloomChange(-4f);

            if (health.bloom.intensity.value <= 0.6)
            {
                health.bloom.active = false;
            }
        }
        if (bGood && health.sanity > 40)
        {
            BloomChange(0.5f);
        }
        if (bGood && health.sanity > 40)
        {
            if(run<3)
            run++;

            if (run == 1)
            {
                
            }

            sleep.run.canRun = true;
        }

            if (bGood && health.sanity > 10)
        {
            if (crouch < 3)
                crouch++;

            
            if(crouch == 1) 
            {
               
            }

            sleep.crouch.crouchCan = true;
            sleep.motionBlur.active = false;
            sleep.cAberration.active = false;

            BloomChange(0.9f);
        }
    }

    public void PanelDmg()
    {
        if(health.sanity > 61)
        {
            Good();
        }

        if (health.sanity <= 60)
        {
            SanitySixty();
        }
        if (health.sanity <= 40)
        {
            SanityForty();
        }
        if (health.sanity <= 20)
        {
            SanityTwenty();
        }
        if (health.sanity <= 10)
        {
            SanityTen();            
        }
        if (health.sanity <= 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            health.inv.SetActive(false);
            Debug.Log("Mike murio");
            health.death = true;
            Time.timeScale = 0;
            gameOver.SetActive(true);
            cam.SetActive(true);
            cam.transform.position = prota.transform.position;
            prota.SetActive(false);                      
            //Destroy(health.player);
        }
    }

    public void Good()
    {
        if (bGood)
        {
            if(good<3)
            good++;

            if (good == 1)
            {
                print("Recupero el aliento");

                bGood = false;

                sixty = 0;
                forty = 0;
                twenty = 0;
                ten = 0;
                run = 0;
                crouch = 0;
            }

           
        }
      
    }

    public void SanitySixty()
    {
        if (sixty < 3)
            sixty++;


        BloomChange(0.5f);

        if (sixty == 1)
        {
            good = 0;
            bGood = true;
            print("Esta en 60 de cordura");
            health.bloom.active = true;
        }
    }

    public void SanityForty()
    {        
        if(forty<3)
        forty++;

        BloomChange(0.9f);

        if (forty == 1)
        {
            print("Esta en 40 de cordura");
            sleep.run.canRun = false;

        }
    }

    public void SanityTwenty()
    {
        if(twenty< 3)
        twenty++;

        //Modo Sueño

        if (twenty == 1)
        {
            print("Esta en 20 de cordura");
            print("Modo Sueño + bloom");
            
        }
    }

    public void SanityTen()
    {
        if (ten < 3)
            ten++;

        BloomChange(1.5f);

        if (ten == 1)
        {
            print("Esta en 10 de cordura");
            sleep.crouch.crouchCan = false;
            sleep.motionBlur.active = true;
            sleep.cAberration.active = true;
        }
    }

    public void BloomChange(float Inten)
    {
        float curreentIn = health.bloom.intensity.value;
        float newInten = Mathf.Lerp(curreentIn, Inten, changeSpeed * Time.deltaTime);
        health.bloom.intensity.value = newInten;
    }
}
