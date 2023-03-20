using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlepBoss : MonoBehaviour
{
    [SerializeField] private GameObject boss, doorFinal;
    [SerializeField] private SleepMode sleep;
    [SerializeField] private int count;
    [SerializeField] private float time, maxTime;

    

    private void Update()
    {
        Sleep();
    }

    public void Sleep()
    {
        if (boss == null)
        {
            Destroy(doorFinal);

            if(count<3)
            count++;

            if (count == 1)
            {
                sleep.ModeDreams();
            }

            time += Time.deltaTime;

            if (time >= maxTime)
            {
                time = 0;
                Destroy(gameObject);
                sleep.OffDreams();
            }
        }
    }
}
