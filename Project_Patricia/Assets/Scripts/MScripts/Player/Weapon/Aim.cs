using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Weapon weapon;
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
        if (Input.GetMouseButtonDown(1) && weapon.save)
        {
            cam.fieldOfView = 45;
        }
        else if (Input.GetMouseButtonUp(1) || !weapon.save) 
        {
            cam.fieldOfView = 60;
        }
    }
}
