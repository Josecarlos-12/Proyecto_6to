using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CamLimitAnim : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject prota, container;
    

    public void CamTransform()
    {
        prota.transform.position= cam.transform.position;
        prota.transform.rotation = cam.transform.rotation;
        prota.SetActive(true);
        container.SetActive(false);
    }
}
