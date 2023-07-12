using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimationFinish : MonoBehaviour
{
    [SerializeField] private GameObject player, cam, point;
    [SerializeField] private GameObject repeat;
    [SerializeField] private RepeatText repeatText;
    [SerializeField] AudioClip clip;


    public void Cam()
    {
        player.SetActive(true);        
        player.transform.position = point.transform.position;
        player.transform.rotation = point.transform.rotation;
        repeat.SetActive(true);
        repeatText.sText = "Mike Schmith: iré a recibirla";
        repeatText.clip = clip; 

        cam.SetActive(false);
    }
}
