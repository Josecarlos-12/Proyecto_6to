using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggertDestroy : MonoBehaviour
{
    [SerializeField] private int count;
    [SerializeField] private GameObject lanterSound;
    [SerializeField] private ActiveBoss boss;

    public enum ActiCheck
    {
        active, Chechk
    }
    public ActiCheck aCheck;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (aCheck)
            {
                case ActiCheck.active:
                    if (count < 3)
                        count++;

                    if (count == 1)
                    {
                        lanterSound.SetActive(true);
                        Destroy(gameObject);
                    }
                    break;
                case ActiCheck.Chechk: 
                    boss.active = true;
                    Destroy(gameObject);
                    break;
            }

           
        }
    }
}
