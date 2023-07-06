using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleOff : MonoBehaviour
{
    [SerializeField] private GameObject cam, prota, point;
    [SerializeField] private GameObject hud;
    [SerializeField] private Animator rifle;
    [SerializeField] private AudioSource[] sound;   

    [Header("Call Other Script")]
    [SerializeField] private GrabRifleSounds grabRifle;

    public void RifleColor()
    {
        rifle.enabled= true;
    }

 public void AnimationOff()
    {
        hud.SetActive(true);
        prota.transform.position= point.transform.position;
        prota.transform.rotation= point.transform.rotation;
        cam.SetActive(false);
        prota.SetActive(true);
        grabRifle.grab = true;

        for (int i = 0; i < sound.Length; i++)
        {
            sound[i].Play();
        }
    }

}
