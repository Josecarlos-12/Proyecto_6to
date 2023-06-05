using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBattleMike : MonoBehaviour
{
    [SerializeField] private GameObject mike;
    [SerializeField] private GameObject otherCol;
    [SerializeField] private MikeBossLevel2 life;
    [SerializeField] private AudioSource sound3;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sound3.Stop();
            mike.SetActive(true);
            Destroy(otherCol);
            life.life = 0;
            Destroy(this.gameObject);
        }
    }

}
