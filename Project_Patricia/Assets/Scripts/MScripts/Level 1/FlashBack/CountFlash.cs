using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountFlash : MonoBehaviour
{
    public GrabFlashBack[] grab;
    public GrabFlashBackV2[] grabv2;
    [SerializeField] private AudioSource ringtone;
    [SerializeField] private int count;
    public bool ring;
    public GameObject cat, chair, episode;
    [SerializeField] private GameObject house, newHouse;


    public enum State
    {
        flash, cat
    }
    public State state;

    private void Update()
    {
        switch (state)
        {
            case State.flash:
                GrabFlas();
                break;
            case State.cat:
                GrabPaint();
                break;
        }
        
    }

    public void GrabPaint()
    {
        int contador = 0;
        for (int i = 0; i < grabv2.Length; i++)
        {

            if (grabv2[i].grab == true)
            {
                contador++;
                if (contador == grabv2.Length)
                {
                    if (count < 3)
                    {
                        count++;
                    }

                    if (count == 1)
                    {
                        ringtone.Play();
                        cat.SetActive(true);
                        //chair.SetActive(true);
                        episode.SetActive(true);
                        newHouse.SetActive(true);
                        house.SetActive(false);
                    }
                }
            }
        }
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
                    if(count<3)
                    {
                        count++;
                    }

                    if (count == 1)
                    {
                        print("Count1");
                        StartCoroutine("Ring");
                    }
                }
             }
        }
    }

    public IEnumerator Ring()
    {
        newHouse.SetActive(true);
        house.SetActive(false);
        yield return new WaitForSeconds(10);
        ringtone.Play();
        ring= true;
        print("Play");
    }
}
