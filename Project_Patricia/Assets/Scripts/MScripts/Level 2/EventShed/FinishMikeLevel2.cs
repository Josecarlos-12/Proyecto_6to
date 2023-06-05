using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishMikeLevel2 : MonoBehaviour
{
    [SerializeField] private GameObject prota;
    [SerializeField] private GameObject cam;

    public void Finish()
    {
        prota.SetActive(true);
        cam.SetActive(false);
    }
}
