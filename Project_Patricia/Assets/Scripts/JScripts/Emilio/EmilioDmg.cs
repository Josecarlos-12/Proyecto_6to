using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmilioDmg : MonoBehaviour
{
    public GameObject player;
    private float damageRange;
    public float damageset = 15f;
    //public float minDamage;
    //public float maxDamage;

    //public bool randomDamage;
    public bool setDamage;

    // Start is called before the first frame update
    void Start()
    {
        //damageRange = Random.Range(minDamage, maxDamage);
    }

    void OntriggerEnter(Collider other)
    {
        /*if(other.gameObject.tag=="Player" && randomDamage )
        {
            player.GetComponent<PlayerHealth>().sanity -= damageRange;
        }*/

        if(other.gameObject.tag=="Player")
        {
            player.GetComponent<PlayerHealth>().sanity -= damageRange;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
