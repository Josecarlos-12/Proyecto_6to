using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityPills : MonoBehaviour
{
    public float addSanity = 25f;
    private float currentSanity;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentSanity = player.GetComponent<PlayerHealth>().sanity;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && player.GetComponent<PlayerHealth>().sanity < 100 ) 
        {
            Debug.Log("Tomaste pastillas");
            player.GetComponent<PlayerHealth>().sanity += addSanity;
        }
    }
}
