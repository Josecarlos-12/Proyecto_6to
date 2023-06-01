using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;

public class SteepsCats : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform posFinish;
    [SerializeField] private int count;
    [SerializeField] private GameObject chart, wallFalse, colliderMove;

    [Header("Character")]
    [SerializeField] private PlayerFPSt move;
    [SerializeField] private CameraLook cam;


    [Header("Cam Follow Steeps")]
    [SerializeField] private GameObject prota;
    [SerializeField] private GameObject camSee, camProta;

    [Header("Dream")]
    [SerializeField] private GameObject eyes;
    [SerializeField] private WakingUpMode wakingUp;

    [SerializeField] private CameraLook camLook;
    [SerializeField] private CatDoorSotano cat;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
      agent.destination =   posFinish.position;

        if(Vector3.Distance(transform.position, posFinish.position) < 3)
        {
            
            if (count<3)
            count++;

            if (count == 1)
            {
                cat.into = true;
                colliderMove.SetActive(false);
                chart.SetActive(true);
                wallFalse.SetActive(false);
                move.canWalk = true;
                cam.moveCamera = true;
                camSee.SetActive(false);
                prota.SetActive(true);
                cam.xRotation= 0;
                float rotY=camSee.transform.rotation.eulerAngles.y;
                prota.transform.rotation = Quaternion.Euler(0, rotY, 0);
                this.gameObject.GetComponent<AudioSource>().Stop();
                camLook.moveCamera = true;
                StartCoroutine("SteepsFinish");
            }
        }
    }

    public IEnumerator SteepsFinish()
    {
        eyes.SetActive(true);
        wakingUp.WakingOn();
        yield return new WaitForSeconds(0.5f);
        wakingUp.WakingOff();
        yield return new WaitForSeconds(0.5f);
        wakingUp.WakingOn();
        yield return new WaitForSeconds(0.5f);
        wakingUp.WakingOff();
        yield return new WaitForSeconds(0.5f);
        wakingUp.WakingOn();
        yield return new WaitForSeconds(1);
        eyes.SetActive(false);
        //this.gameObject.SetActive(false);
    }
}
