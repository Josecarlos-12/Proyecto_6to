using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventary : MonoBehaviour
{
    public bool rifle, bPills, bKEy, bKeyComfi;
    public Sprite sRifle, sKey, sPill;
    public Image image;
    public int pills, pillsTakes;
    public TextMeshProUGUI count;
    [SerializeField] private GameObject cam, prota, panel;
    [SerializeField] private bool one;
    public AudioSource boxMusic;

    [Header("Call Other Script")]
    [SerializeField] private PlayerHealth sanity;
    [SerializeField] private Rifle rRifle;

    public enum Dream
    {
        none, sleep
    }
    public Dream dream;

    void Start()
    {
        rifle= true;
        //image.sprite = sRifle;
        count.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            rifle = true;
            bPills = false;
            bKeyComfi = false;
        }
        if(rifle)
        {
            if (rRifle.canRifle)
            {
                count.text = string.Empty;               
                image.sprite = sRifle;
                Debug.Log("Rifle");                
            }
            else if (!rRifle.canRifle)
            {
                count.text = string.Empty;
                image.sprite = null;
                bPills = false;
                bKeyComfi = false;
            }
        }

        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            rifle = false;
            bPills = true;
            bKeyComfi= false;
        }
        if(bPills)
        {
            if (pills > 0)
            {                
                image.sprite = sPill;
                count.text = "X" + pills.ToString();
                Debug.Log("Pastilla");
            }
            if (pills <= 0)
            {
                count.text = string.Empty;
                image.sprite = null;
            }
        }


        /* if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            bKeyComfi = true;
            rifle = false;
            bPills= false;
            count.text = string.Empty;
        }
        if(bKeyComfi)
        {
            if (bKEy)
            {                
                image.sprite = sKey;
                Debug.Log("Llaves");
            }
            else
            {
                image.sprite = null;
            }
        }*/

        Pills();
    }

    public void Pills()
    {
        if(bPills && pills > 0 && Input.GetMouseButtonDown(0))
        {
            pills--;
            sanity.sanity += 5;

            switch (dream)
            {
                case Dream.none: break;
                    case Dream.sleep:
                    pillsTakes++;

                    if (pillsTakes == 3)
                    {
                        if (one)
                            return;
                        prota.SetActive(false);
                        panel.SetActive(true);
                        cam.SetActive(true);
                    }
                    break;
            }
        }
    }
}
