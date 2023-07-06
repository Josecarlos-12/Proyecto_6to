using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightsL2 : MonoBehaviour
{
    [SerializeField] private MeshRenderer spot;
    [SerializeField] private Material normal, emissive;

    private void OnEnable()
    {
        spot.material= emissive;
    }

    private void OnDisable()
    {
        spot.material= normal;
    }
}
