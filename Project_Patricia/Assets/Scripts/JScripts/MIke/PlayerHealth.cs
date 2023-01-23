using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject inv;
    public GameObject player;

    public float sanity = 100f;

    public GameObject jumpScare;

    public PlayerCamera cam;
    public bool bjumpScare;
    
    public float timer;
    public float maxTimer;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( sanity <= 0 )
        {
            //player.GetComponent<PlayerMS>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            inv.SetActive(false);
        }
        if ( sanity > 100 )
        {
            sanity = 100;
        }
        if ( bjumpScare )
        {
            timer += Time.deltaTime;
            if ( timer >= maxTimer )
            {
                jumpScare.SetActive(false);
                bjumpScare = false;
                timer = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.CompareTag("Emilio") )
        {
            Debug.Log("AAAAAAA me asuste");
            jumpScare.SetActive(true);
            bjumpScare = true;
        }
    }
}
