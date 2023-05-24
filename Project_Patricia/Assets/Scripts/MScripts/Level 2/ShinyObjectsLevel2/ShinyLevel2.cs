using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShinyLevel2 : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] bool into;
    public bool on;
    [SerializeField] private GameObject repeat;

    [Header("Dishes")]
    [SerializeField] PickableObject pick;

    [Header("CookingPot")]
    [SerializeField] private OpenDoorBathroom active;


    public enum ObjectGames
    {
        CookingPot, spoons, dishes, glasses
    }
    public ObjectGames objGames;

    private void Update()
    {
        switch (objGames)
        {
            case ObjectGames.dishes:
                if (!pick.isPickable && !on)
                {
                    anim.SetBool("On", false);
                }                    
                break;
            case ObjectGames.glasses:
                if (!pick.isPickable)
                {
                    anim.SetBool("On", false);
                }
                break;
        }
    }

    public void RepeatOn()
    {
        repeat.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ShinyObjects"))
        {
            switch (objGames)
            {
                case ObjectGames.CookingPot:
                    if (active.bActive)
                    {
                        anim.SetBool("On", true);
                    }
                    break;
                case ObjectGames.spoons:
                    if (on)
                    {
                        anim.SetBool("On", true);
                    }
                    break;
                case ObjectGames.dishes:
                    if (pick.isActiveAndEnabled || on)
                    {
                        anim.SetBool("On", true);
                    }
                    break;
                case ObjectGames.glasses:
                    if (pick.isPickable)
                    {
                        anim.SetBool("On", true);
                    }
                    break;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ShinyObjects"))
        {
            anim.SetBool("On", false);
            into = false;
        }
    }
}
