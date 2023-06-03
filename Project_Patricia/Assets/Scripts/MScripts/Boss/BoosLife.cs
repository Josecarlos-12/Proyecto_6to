using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosLife : MonoBehaviour
{
    [SerializeField] private MoveBoss move;
    [SerializeField] private TPBossLevel1 bossLevel1;
    [SerializeField] private MikeBossLevel2 level2;

    public enum Levels
    {
        one, two
    }
    public Levels levels;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BulletPlayer"))
        {
            switch (levels)
            {
                case Levels.one:
                    print("Toco");
                    bossLevel1.TouchTriBoss();
                    break;
                case Levels.two:
                    print("Toco");
                    level2.TouchTriBoss();
                    break;
            }
            
        }
    }
}
