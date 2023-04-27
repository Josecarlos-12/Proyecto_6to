using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBoss : MonoBehaviour
{
    public bool active, active2;
    [SerializeField] public GameObject boss;
    [SerializeField] public float time, maxTime;

    private void Update()
    {
        if(boss!= null)
        {
            if (active2)
            {                
                boss.SetActive(true);
            }
        }
    }
}
