using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelOne : MonoBehaviour
{
    [SerializeField] private GameObject cam, prota;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        cam.SetActive(false);
        prota.SetActive(true);
    }
}
