using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosLife : MonoBehaviour
{
    [SerializeField] private MoveBoss move;
    [SerializeField] private TPBossLevel1 bossLevel1;
    [SerializeField] private MikeBossLevel2 level2;

    [Header("Level 2")]
    [SerializeField] private bool into;
    [SerializeField] private int count;
    [SerializeField] private GameObject gameLight;

    public enum Levels
    {
        one, two
    }
    public Levels levels;

    private void Update()
    {
        switch (levels)
        {
            case Levels.two:
                if (level2.offLight && into)
                {
                    if (count < 3)
                        count++;

                    if (count == 1)
                    {
                        if (gameLight.GetComponent<Light>().enabled)
                        {
                            gameLight.transform.parent.GetComponent<Animator>().SetBool("Off", true);
                        }
                    }
                }

                if (!level2.offLight)
                {
                    count = 0;
                }
                break;
        }
    }

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

        switch (levels)
        {
            case Levels.two:
                if (other.gameObject.name == "Spot Light")
                {
                    print("Spot");
                    gameLight = other.gameObject;
                    into = true;
                }
                break;
        }
        
    }
}
