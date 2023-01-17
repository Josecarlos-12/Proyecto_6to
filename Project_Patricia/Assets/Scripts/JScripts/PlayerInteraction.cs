using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private RaycastHit hit;
    [SerializeField] private float distance;
    private LayerMask door;
    [HideInInspector] public bool bDoor, bHandle, bLife, bPills;

    [Header("Press")]
    [SerializeField] private GameObject texE;

    [Header("Objects Destroy")]
    [SerializeField] private GameObject gameLife;
    [SerializeField] private GameObject gameHandle;
    [SerializeField] private GameObject gamePills;

    //[Header("Call other Scripts")]
    //[SerializeField] private PlayerLife life;
    //[SerializeField] private Weapon weapon;
    

    private void Update()
    {
        Detected();
        Press();
    }

    public void Detected()
    {
        //Raycast con tag no detecta si hay algun objeto al frente de tu objetivo
        if (Physics.Raycast(cam.transform.position, cam.forward, out hit, distance))
        {
            if (hit.transform.CompareTag("Door"))
            {
                texE.SetActive(true);
                bDoor = true;
            }

            /*if (hit.transform.CompareTag("Handle"))
            {
                texE.SetActive(true);
                gameHandle = hit.transform.gameObject;
                bHandle = true;
            }*/

            /*if (hit.transform.CompareTag("life"))
            {
                texE.SetActive(true);
                gameLife = hit.transform.gameObject;
                bLife = true;
            }*/

            if ( hit.transform.CompareTag("Pills") )
            {
                texE.SetActive(true);
                gamePills=hit.transform.gameObject;
                bPills= true;
            }        
        }
        else
        {
            texE.SetActive(false);
            bDoor = false;
            bHandle = false; 
            bLife = false;
            bPills= false;
        }

        //raycast con layer detectar si hay algo al frente de tu objetivo
        if(Physics.Raycast(cam.transform.position, cam.forward, out hit, distance, door))
        {
            
        }
    }

    public void Press()
    {
        /*if(bHandle && Input.GetKeyDown(KeyCode.E))
        {
            //weapon.handle += 1;
            Destroy(gameHandle);
            bHandle = false;
            texE.SetActive(false);
        }*/
        /*if (bLife && Input.GetKeyDown(KeyCode.E))
        {
            //life.ReloadLife();
            Destroy(gameLife);
            bLife = false;
            texE.SetActive(false);
        }*/

        if(bPills && Input.GetKeyDown(KeyCode.E) )
        {
            Debug.Log("Recogiste pastillas");
            Destroy(gamePills);
            bPills= false;
            texE.SetActive(false);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(cam.position, cam.forward * distance);           
    }
}
