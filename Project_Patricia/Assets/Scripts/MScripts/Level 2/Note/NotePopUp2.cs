using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePopUp2 : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    [SerializeField] private Camera cam;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000, layer))
            {
                    // Se ha hecho clic en un objeto
                    GameObject objetoClicado = hit.collider.gameObject;
                    Debug.Log("Se ha hecho clic en: " + objetoClicado.name);

                    // Obtener las coordenadas del punto de impacto
                    Vector3 coordenadasImpacto = hit.point;
                    Debug.Log("Coordenadas de impacto: " + coordenadasImpacto);      
            }
        }
    }
}
