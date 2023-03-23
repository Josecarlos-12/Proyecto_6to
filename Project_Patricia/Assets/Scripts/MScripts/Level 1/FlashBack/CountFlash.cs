using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountFlash : MonoBehaviour
{
    public GrabFlashBack[] grab;
    [SerializeField] private AudioSource ringtone;

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
                    int count = 0;
                    if(count<3)
                    {
                        count++;
                    }

                    if (count == 1)
                    {
                        StartCoroutine("Ring");
                    }
                }
             }
        }
    }

    public IEnumerator Ring()
    {
        yield return new WaitForSeconds(10);
        ringtone.Play();
    }
}
