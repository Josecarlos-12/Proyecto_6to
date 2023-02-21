using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Weapon weapon;
    [SerializeField] private bool mouse;

    [Header("Call Other Script")]
    [SerializeField] private Pause pause;
    [SerializeField] private NotesUI notes;
    [SerializeField] private Inventary inve;
    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        AimWeapon();
    }

    public void AimWeapon()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mouse = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            mouse = false;
        }


        if (pause.shoot && notes.shoot)
        {
            if (mouse && weapon.save)
            {
                cam.fieldOfView = 45;
            }
            
        }
        if (!mouse || !weapon.save || !inve.rifle)
        {
            cam.fieldOfView = 60;
        }
        if(mouse && !weapon.save)
        {
            cam.fieldOfView = 60;
        }

        if (!inve.rifle)
        {
            mouse = false;
            weapon.save= false;
        }
    }
}
