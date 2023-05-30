using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class Weapon : MonoBehaviour
{
    [Header("Weapon")]
    public bool canShoot, save, shoot, shootTwo;
    [SerializeField] private float initialShoot, timeShoot, saveTime, saveTimeMax;
    public GameObject bullet, weapon, aim;
    [SerializeField] private Transform initialBullet;
    [SerializeField] private Text bulletText, handleText;
    [SerializeField] private GameObject bulletContainer;
    [SerializeField] private Animator animBullet, animRifle;

    [Header("Reload")]
    public int handle = 2;
    public int clicks = 10, clickMax=10;

    [Header("Call Other Script")]
    public PlayerInteraction obj;
    public Inventary inventary;
    public Pause pause;
    public NotesUI notes;
    public PlayerInteraction inte;
    public PlayerHealth health;

    [Header("Sound")]
    [SerializeField] AudioSource shootSound;

    private void Start()
    {
        obj=GetComponent<PlayerInteraction>();
        weapon.SetActive(false);
        aim.SetActive(false);
    }

    private void Update()
    {
        if (shootTwo)
        {
            BulletContainer();
            SaveWeapon();
            Shoot();
            Reloaded();
        }        
    }

    public void BulletContainer()
    {
        bulletText.text= clicks.ToString();
        handleText.text = handle.ToString();
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
        if (Input.GetKeyDown(KeyCode.Alpha1) && !obj.inHand &&  inventary.rifle)
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

        /*if (!shoot && save)
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
        }*/
    }

    public void Shoot()
    {
        if (!save && Input.GetMouseButtonDown(0) && canShoot && !obj.inHand && inventary.rifle && pause.shoot && notes.shoot && inte.shoot)
        {
            weapon.SetActive(true);
            aim.SetActive(true);
            bulletContainer.SetActive(true);
            animBullet.SetBool("Exit", false);
            save = true;
        }

        if (canShoot && save && pause.shoot && notes.shoot && inte.shoot)
        {          
            if (Input.GetMouseButtonDown(0) && Time.time > initialShoot && clicks > 0 && !obj.inHand && inventary.rifle)
            {
                animRifle.SetBool("Shoot", true);
                StartCoroutine("ShootFalse");
                shootSound.Play();
                animBullet.SetBool("Exit", false);
                Instantiate(bullet, initialBullet.transform.position, initialBullet.transform.rotation);
                health.sanity -= 4;
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

    public IEnumerator ShootFalse()
    {
        yield return new WaitForSeconds(0.15f);
        animRifle.SetBool("Shoot", false);
    }
}
