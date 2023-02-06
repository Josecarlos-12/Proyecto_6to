using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
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

    public Volume volume;
    public Bloom bloom;
    public bool blm;

    // Start is called before the first frame update
    void Start()
    {
        //cam = GetComponent<PlayerCamera>();
        volume.profile.TryGet(out Bloom bl);
        bloom = bl;
    }

    private void FixedUpdate()
    {
        float valuealpha = transparence;
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

        PanelDmg();
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
    }

    public void PanelDmg()
    {
        if (sanity > 125)
        {
            //Muerte por sobredosis
            Debug.Log("Me mori por drogadicto");
            Destroy(gameObject);
        }
        if (sanity > 101)
        {
            sanity += 0.1f;
            transparence = transparence + 0.001f;
            Debug.Log("que se empiece a blurrear la pantalla");
            Debug.Log("Recibir daño por seg");
        }

        if(sanity > 50)
        {
            //Efecto de sueño
            bloom.intensity.value += 0.1f;
            Debug.Log("Tengo mucho sueño");
        }
    }
}
