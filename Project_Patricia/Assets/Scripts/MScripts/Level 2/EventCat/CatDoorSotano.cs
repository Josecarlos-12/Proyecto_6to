using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CatDoorSotano : MonoBehaviour
{
    [SerializeField] private bool into;
    [SerializeField] private int count;
    [SerializeField] private GameObject steeps;
    [SerializeField] private GameObject catEnemy;   

    [Header("Character")]
    [SerializeField] private PlayerFPSt move;
    [SerializeField] private CameraLook cam;


    [Header("Cam Follow Steeps")]
    [SerializeField] private GameObject prota;
    [SerializeField] private GameObject camSee, camProta;

    [Header("Call Other Script")]
    [SerializeField] private LightInRoom room;


    private void Update()
    {
        if (!into)
        {
            if(count<3)
            count++;

            if (count == 1)
            {
                move.canWalk = false;
                cam.moveCamera = false;
                steeps.SetActive(true);
                camSee.SetActive(true);
                prota.SetActive(false);
                camSee.transform.position = camProta.transform.position;
                catEnemy.SetActive(false);
                StartCoroutine("Light");
            }
            camSee.transform.LookAt(steeps.transform.position);
        }
    }

    public IEnumerator Light()
    {
        for (int i = 0; i < room.up.Length; i++)
        {
            room.up[i].SetActive(false);
        }

        for (int i = 0; i < room.down.Length; i++)
        {
            room.down[i].SetActive(false);
        }

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < room.up.Length; i++)
        {
            room.up[i].SetActive(true);
        }

        for (int i = 0; i < room.down.Length; i++)
        {
            room.down[i].SetActive(true);
        }

        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < room.up.Length; i++)
        {
            room.up[i].SetActive(false);
        }

        for (int i = 0; i < room.down.Length; i++)
        {
            room.down[i].SetActive(false);
        }

        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < room.up.Length; i++)
        {
            room.up[i].SetActive(true);
        }

        for (int i = 0; i < room.down.Length; i++)
        {
            room.down[i].SetActive(true);
        }

        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < room.up.Length; i++)
        {
            room.up[i].SetActive(false);
        }

        for (int i = 0; i < room.down.Length; i++)
        {
            room.down[i].SetActive(false);
        }

        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < room.up.Length; i++)
        {
            room.up[i].SetActive(true);
        }

        for (int i = 0; i < room.down.Length; i++)
        {
            room.down[i].SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = false;
        }
    }

   
}
