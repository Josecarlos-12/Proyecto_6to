using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharlieBushes : MonoBehaviour
{
    [SerializeField] private float size;
    [SerializeField] private Transform player;
    [SerializeField] private int count;
    [SerializeField] private AudioSource bush;
    [SerializeField] private GameObject charlie, charSpawn;

    [Header("Call Other Script")]
    [SerializeField] private PunchCharlie pCharlie;

    public enum Enemy
    {
        none, Charlie
    }
    public Enemy enemy;

    private void Update()
    {
        Detected();
    }

    public void Detected()
    {
        if (Vector3.Distance(transform.position, player.position) < size)
        { 
            if(count<3)
            count++;

            if (count == 1)
            {
                bush.Play();
                switch (enemy)
                {
                    case Enemy.none:
                        break;
                        case Enemy.Charlie:
                        charSpawn = Instantiate(charlie,transform.position,transform.rotation);
                        charSpawn.transform.parent = transform.parent;
                        charSpawn.SetActive(true);

                        break;
                }

            }
        }
        else
        {
            count = 0;
        }

        if(charSpawn!= null)
        {
            if (Vector3.Distance(transform.position, charSpawn.transform.position) > size)
            {
                Transform tran1 = charSpawn.transform.GetChild(0);
                Transform tran2 = tran1.transform.GetChild(0);
                Transform tran3 = tran2.transform.Find("Punch");
                tran3.transform.gameObject.GetComponent<PunchCharlie>().touch = true;
                print(tran3.name);
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, size);
    }
}
