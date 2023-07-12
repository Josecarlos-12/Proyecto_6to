using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

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
    [SerializeField] private GameObject mikeWalk, inteDoor;
    [SerializeField] private Animator animDoor;

    [Header("Environment")]
    [SerializeField] private GameObject sun;
    [SerializeField] private GameObject moon;
    [SerializeField] private Light sunLight;
    [SerializeField] private Volume volume;
    [SerializeField] private Fog fog;
    [SerializeField] private CloudLayer cloudLayer;

    [SerializeField] private AudioSource cry;
    [SerializeField] private AudioClip clip;

    private void Awake()
    {
        if (volume != null)
        {
            volume.profile.TryGet(out Fog vFog);
            fog = vFog;

            volume.profile.TryGet(out CloudLayer vCloud);
            cloudLayer= vCloud;
        }
    }

    public void Cry()
    {
        cry.clip = clip;
        cry.Play();
    }

    public void ChangeLight()
    {
        fog.active = false;
        sun.transform.rotation = Quaternion.Euler(25.1f, 83.097f, -1.791f);
        sunLight.intensity = 40;
        cloudLayer.active= false;
        moon.SetActive(false);
    }

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
        animDoor.SetBool("Close", false);
        inteDoor.SetActive(true);
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
