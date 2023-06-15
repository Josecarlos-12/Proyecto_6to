using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PopUpEvents : MonoBehaviour
{
    [SerializeField] private GameObject eyes;
    [SerializeField] private Animator camPopUp;
    [SerializeField] private GameObject cam, prota;
    [SerializeField] private AudioSource door;

    [Header("Shadow Mike")]
    [SerializeField] private Animator shadowMike;
    [SerializeField] private GameObject mike;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform point;
    [SerializeField] private GameObject mikeWalk;

    public void OpenEyes()
    {
        eyes.SetActive(true);
    }

    public void Flip()
    {
        camPopUp.SetBool("Flip", true);
    }

    public void FlipMike()
    {
        shadowMike.SetBool("Flip", true);
    }

    public void Walk()
    {
        mikeWalk.SetActive(true);
        mike.SetActive(false);
        shadowMike.SetBool("Walk", true);
        agent.destination = point.position;
    }

    public void TranformMike()
    {
        print("D");
        mike.transform.rotation = Quaternion.identity;
    }

    public void Finish()
    {
        door.Play();
        cam.SetActive(false);
        prota.SetActive(true);
        prota.transform.position = cam.transform.position;
        prota.transform.rotation = Quaternion.Euler(0, 90, 0);
    }
}
