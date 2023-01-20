using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private TextMeshProUGUI bulletText;
    [SerializeField] private GameObject bulletContainer;
    [SerializeField] private Animator animBullet;

    [Header("Reload")]
    public int handle = 2;
    public int clicks = 10, clickMax=10;

    [Header("Call Other Script")]
    public PlayerInteraction obj;
    public Inventary inventary;

    private void Start()
    {
        obj=GetComponent<PlayerInteraction>();
        weapon.SetActive(false);
        aim.SetActive(false);
    }

    private void Update()
    {        

        BulletContainer();
        SaveWeapon();
        Shoot();
        Reloaded();
    }

    public void BulletContainer()
    {
        bulletText.text="X" + clicks.ToString();
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
        if (Input.GetKeyDown(KeyCode.F) && !obj.inHand &&  inventary.rifle)
        {
            save = !save;
            if (save)
            {
                weapon.SetActive(true);
                aim.SetActive(true);
                bulletContainer.SetActive(true);
                animBullet.SetBool("Exit", false);
            }
            else if (!save)
            {
                weapon.SetActive(false);
                aim.SetActive(false);
                animBullet.SetBool("Exit", true);
            }            
        }

        if (obj.inHand)
        {
            weapon.SetActive(false);
            aim.SetActive(false);
            animBullet.SetBool("Exit", true);
        }

        if (!inventary.rifle)
        {
            weapon.SetActive(false);
            aim.SetActive(false);
            //animBullet.SetBool("Exit", true);
        }

        if (!shoot && save)
        {
            saveTime += Time.deltaTime;

            if(saveTime > saveTimeMax)
            {
                saveTime = 0;
                save = false;
                weapon.SetActive(false);
                aim.SetActive(false);
                animBullet.SetBool("Exit", true);
            }
        }
        else
        {
            saveTime = 0;
        }
    }

    public void Shoot()
    {
        if (!save && Input.GetMouseButtonDown(0) && canShoot && !obj.inHand && inventary.rifle)
        {
            weapon.SetActive(true);
            aim.SetActive(true);
            bulletContainer.SetActive(true);
            animBullet.SetBool("Exit", false);
            save = true;
        }

        if (canShoot && save)
        {          
            if (Input.GetMouseButtonDown(0) && Time.time > initialShoot && clicks > 0 && !obj.inHand && inventary.rifle)
            {                                                  
                animBullet.SetBool("Exit", false);
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
