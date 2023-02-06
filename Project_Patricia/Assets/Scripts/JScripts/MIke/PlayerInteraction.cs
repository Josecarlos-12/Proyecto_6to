using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private Transform objUi;
    [SerializeField] private RaycastHit hit;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask layer;
    public bool bDoor, bHandle, bLife, bPills, bObj, inHand, bKey;

    [Header("Press")]
    [SerializeField] private GameObject texE;

    [Header("Objects Destroy")]
    [SerializeField] private GameObject gameLife;
    [SerializeField] private GameObject gameHandle;
    [SerializeField] private GameObject gamePills;
    [SerializeField] private GameObject gameKeys;
    [SerializeField] private GameObject gameObj, transGame;

    [Header("Call other Scripts")]
    //[SerializeField] private PlayerLife life;
    [SerializeField] private Weapon weapon;
    //[SerializeField] private PlayerCamera playerCam;
    [SerializeField] private Inventary invePills;

    public Animator door;
    public Image aim;

    [Header("Not Shoot")]
    [SerializeField] private float distance2;
    [SerializeField] private RaycastHit hit2;
    

    private void Update()
    {        
        Detected();
        Press();
        NotShoot();
        //GrabObject();
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

            if (hit.transform.CompareTag("Handle"))
            {
                texE.SetActive(true);
                gameHandle = hit.transform.gameObject;
                bHandle = true;
            }
            else if (!hit.transform.CompareTag("Handle"))
            {
                bHandle=false;
            }

            if (hit.transform.CompareTag("objCamera"))
            {
                texE.SetActive(true);
                gameObj = hit.transform.gameObject;
                transGame=hit.transform.gameObject;
                bObj = true;                
            }
            else if (!hit.transform.CompareTag("objCamera"))
            {
                bObj= false;
            }

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
            else if (!hit.transform.CompareTag("Pills"))
            {
                bPills = false;
            }            


            if (hit.transform.CompareTag("Key"))
            {
                texE.SetActive(true);
                gameKeys = hit.transform.gameObject;
                bKey = true;
            }
            else if (!hit.transform.CompareTag("Key"))
            {
                bKey = false;
            }

           
        }
        else
        {            
            bPills = false;
            bHandle=false;      
            bObj= false;
            bKey= false;          
        }

        if (!bPills && !bHandle && !bObj && !bKey)
        {
            texE.SetActive(false);
        }
    }

    public void NotShoot()
    {
        if (Physics.Raycast(cam.transform.position, cam.forward, out hit2, distance2))
        {
            if (hit2.transform.CompareTag("NotShoot"))
            {
                weapon.canShoot = false;
                aim.color = Color.red;
            }
            else if (!hit2.transform.CompareTag("NotShoot"))
            {
                weapon.canShoot = true;
                aim.color = Color.white;
            }
        }
        else
        {
            weapon.canShoot = true;
            aim.color = Color.white;
        }
    }

    public void Press()
    {
        if(bHandle && Input.GetKeyDown(KeyCode.E))
        {
            weapon.handle += 1;
            Destroy(gameHandle);
            bHandle = false;
            texE.SetActive(false);
        }
        /*if (bLife && Input.GetKeyDown(KeyCode.E))
        {
            //life.ReloadLife();
            Destroy(gameLife);
            bLife = false;
            texE.SetActive(false);
        }*/

        /*if (bObj && Input.GetKeyDown(KeyCode.E))
        {
            inHand = true;
            playerCam.moveCamera = false;
            gameObj.transform.parent = cam;
            gameObj.transform.position = new Vector3(objUi.position.x, objUi.position.y, objUi.position.z);
            gameObj.transform.localScale= new Vector3(gameObj.transform.localScale.x + 0.5f, gameObj.transform.localScale.y + 0.5f, gameObj.gameObject.transform.localScale.z + 0.5f);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            texE.SetActive(false);
        }
        if (!bObj && Input.GetKeyDown(KeyCode.E))
        {
            playerCam.moveCamera = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            inHand = false;
            gameObj.transform.parent = null;
            //gameObj.transform.localScale = new Vector3(gameObj.transform.localScale.x - 0.5f, gameObj.transform.localScale.y - 0.5f, gameObj.gameObject.transform.localScale.z - 0.5f);
        }*/

        if(bPills && Input.GetKeyDown(KeyCode.E) )
        {
            invePills.pills++;
            Destroy(gamePills);
            bPills= false;
            texE.SetActive(false);
        }

        if (bKey && Input.GetKeyDown(KeyCode.E))
        {
            invePills.bKEy = true;
            Destroy(gameKeys);
            bKey = false;
            texE.SetActive(false);
        }
    }

    public void GrabObject()
    {
        if ( inHand=true && Input.GetKeyDown(KeyCode.E))
        {
            //inHand = false;
            //gameObj.transform.parent = null;            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(cam.position, cam.forward * distance);

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(cam.position, cam.forward * distance2);
    }
}
