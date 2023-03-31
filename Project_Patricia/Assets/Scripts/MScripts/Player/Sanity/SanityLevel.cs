using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityLevel : MonoBehaviour
{
    public PlayerHealth health;

    public int sixty, forty, twenty, ten, good;
    public bool bGood, bloomInto, bloomFalse;

    void Start()
    {
        
    }

    void Update()
    {
        PanelDmg();

        if(bGood && health.sanity > 20)
        {
            health.bloom.active = false;
        }
    }

    public void PanelDmg()
    {
        if(health.sanity > 60)
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
            Destroy(health.player);
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
            }

           
        }
      
    }

    public void SanitySixty()
    {
        if (sixty < 3)
            sixty++;


        if (sixty == 1)
        {
            good = 0;
            bGood = true;
            print("Esta en 60 de cordura");
        }
    }

    public void SanityForty()
    {        
        if(forty<3)
        forty++;


        if (forty == 1)
        {
            print("Esta en 40 de cordura");
        }
    }

    public void SanityTwenty()
    {
        if(twenty< 3)
        twenty++;

        if (twenty == 1)
        {
            print("Esta en 20 de cordura");
            
        }
    }

    public void SanityTen()
    {
        if (ten < 3)
            ten++;

        if (ten == 1)
        {
            print("Esta en 10 de cordura");
            health.bloom.active= true;
        }
    }
}
