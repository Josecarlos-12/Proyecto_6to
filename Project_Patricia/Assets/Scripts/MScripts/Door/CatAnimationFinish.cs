using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimationFinish : MonoBehaviour
{
    [SerializeField] private GameObject player, cam, point;

    public void Cam()
    {
        player.SetActive(true);        
        player.transform.position = point.transform.position;
        player.transform.rotation = point.transform.rotation;
        cam.SetActive(false);
    }
}
