using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountFlash : MonoBehaviour
{
    public GrabFlashBack[] grab;

    private void Update()
    {
        GrabFlas();
    }

    public void GrabFlas()
    {
        int contador = 0;
        for(int i = 0; i < grab.Length; i++)
        {

             if(grab[i].grab==true)
             {
                contador++;
                if (contador == grab.Length)
                {
                 Debug.Log("Todo es Verdadero");

                }
             }
        }
    }
}
