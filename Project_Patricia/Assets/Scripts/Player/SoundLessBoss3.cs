using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLessBoss3 : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] AudioSource audi;
    [SerializeField] float time, maxTime;

    private void Update()
    {
        if(boss == null)
        {
            time += Time.deltaTime;
            if(time > maxTime)
            {
                audi.volume -= 0.02f;
            }
        }

        if (audi.volume < 0.01f)
        {
            Destroy(gameObject);
        }
    }
}
