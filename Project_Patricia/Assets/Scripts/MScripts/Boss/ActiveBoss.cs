using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBoss : MonoBehaviour
{
    public bool active;
    [SerializeField] public GameObject boss;
    [SerializeField] public float time, maxTime;

    private void Update()
    {
        if(active && !boss.activeInHierarchy)
        {
            time += Time.deltaTime;

            if(time >= maxTime)
            {
                boss.SetActive(true);
            }
        }
        if(boss.activeInHierarchy)
        {
            time = 0;
        }
    }
}
