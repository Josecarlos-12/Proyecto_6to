using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Weapon : MonoBehaviour
{
    [Header("Weapon")]
    public bool canShoot, save, shoot;
    [SerializeField] private float initialShoot, timeShoot, saveTime, saveTimeMax;
    [SerializeField] private GameObject bullet, weapon, aim;
    [SerializeField] private Transform initialBullet;

    [Header("Reload")]
    public int handle = 2;
    public int clicks = 10, clickMax=10;

    private void Start()
    {
        weapon.SetActive(false);
        aim.SetActive(false);
    }

    private void Update()
    {
        SaveWeapon();
        Shoot();
        Reloaded();
    }

    public void Reloaded()
    {
        if (Input.GetKeyDown(KeyCode.R) && handle > 0)
        {
            canShoot = false;
            shoot = true;
            StartCoroutine("ReloadCcorutine");
        }
    }

    public IEnumerator ReloadCcorutine()
    {
        yield return new WaitForSeconds(3);
        shoot = false;
        canShoot=true;
        handle -= 1;
        clicks = clickMax;
    }

    public void SaveWeapon()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            save = !save;
            if (save)
            {
                weapon.SetActive(true);
                aim.SetActive(true);
            }
            else
            {
                weapon.SetActive(false);
                aim.SetActive(false);
            }
        }

        if(!shoot && save)
        {
            saveTime += Time.deltaTime;

            if(saveTime > saveTimeMax)
            {
                saveTime = 0;
                save = false;
                weapon.SetActive(false);
                aim.SetActive(false);
            }
        }
        else
        {
            saveTime = 0;
        }
    }

    public void Shoot()
    {
        if (!save && Input.GetMouseButtonDown(0) && canShoot)
        {
            weapon.SetActive(true);
            aim.SetActive(true);
            save = true;
        }

        if (canShoot && save)
        {          
            if (Input.GetMouseButtonDown(0) && Time.time > initialShoot && clicks > 0)
            {                                                  
                Instantiate(bullet, initialBullet.transform.position, initialBullet.transform.rotation);                    
                initialShoot = Time.time + timeShoot;
                shoot = true;
                clicks -= 1;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                shoot = false;
            }
        }

    }
}
