using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject inv;
    public GameObject player;

    public float sanity = 100f;
    public float sanityMax = 125f;

    public GameObject jumpScare;

    public PlayerCamera cam;
    public bool bjumpScare;
    
    public float timer;
    public float maxTimer;
    public bool death;
    public float transparence;
    public Image dmg;

    // Start is called before the first frame update
    void Start()
    {
        //cam = GetComponent<PlayerCamera>();
    }

    private void FixedUpdate()
    {
        float valuealpha = transparence / sanity * (sanity - sanityMax);
        dmg.color= new Color(1,1,1,valuealpha);
    }

    // Update is called once per frame
    void Update()
    {
        /*if ( sanity <= 0 )
        {
            //player.GetComponent<PlayerMS>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            inv.SetActive(false);
        }
        if ( sanity > 100 )
        {
            sanity = 100;
        }*/
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
            RecieveDamage(25);
        }
    }

    public void RecieveDamage(int recieveDamage)
    {
        sanity -= recieveDamage;
        if ( sanity <= 0 )
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            inv.SetActive(false);            
            Debug.Log("Mike murio");
            death= true;
            Destroy(gameObject);
        }
        if ( sanity > 100 )
        {
            sanity = 100;
        }
        if (sanity >=125)
        {
            //Se muere patas arriba
            Debug.Log("Me mori por drogadicto");
            Destroy(gameObject);
        }
        if (sanity >= 101) 
        {
            Debug.Log("que se empiece a blurrear la pantalla");
            Debug.Log("Recibir daño por seg");
        }
    }

}
