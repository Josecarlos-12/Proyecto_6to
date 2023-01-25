using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeCanvas : MonoBehaviour
{
    public void CambiarA(GameObject scene)
    {
        scene.SetActive(true);
    }
    public void Remplazar(GameObject scene)
    {
        scene.SetActive(false);
    }
}
