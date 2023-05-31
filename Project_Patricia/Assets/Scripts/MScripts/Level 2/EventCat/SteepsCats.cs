using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
      agent.destination =   posFinish.position;

        if(Vector3.Distance(transform.position, posFinish.position) < 3)
        {
            if(count<1)
            count++;

            if (count == 1)
            {
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
                this.gameObject.SetActive(false);
            }
        }
    }
}
