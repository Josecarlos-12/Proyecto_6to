using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActiveBoss : MonoBehaviour
{
    public bool active, active2;
    [SerializeField] public GameObject boss;
    [SerializeField] public float time, maxTime;
    [SerializeField] private TPBossLevel1 tp;


    private void Update()
    {
        if(boss!= null)
        {
            if (active2)
            {                
                boss.SetActive(true);
            }
        }
        if(Input.GetKeyDown(KeyCode.F11) && active2)
        {
            tp.life = 0;
        }
    }

}
