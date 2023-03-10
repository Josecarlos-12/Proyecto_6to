using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public AudioSource healthSound;

    [Header("SphereCast")]    
    public float size;
    public int count = 0;
    [SerializeField] private SleepMode sleep;
    RaycastHit hit;

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
        Damage();
        SphereCast();
    }

    public void SphereCast()
    {
        Collider[] coll = Physics.OverlapSphere(transform.position, size);

        foreach(Collider collider in coll)
        {
            if (collider.CompareTag("Emilio"))
            {

                if (count < 3)
                    count++;

                if (count == 1)
                {
                    Scream();
                    sleep.ModeDreams();
                    StartCoroutine("OffDreams");
                }
            }
        }
    }
    public IEnumerator OffDreams()
    {
        yield return new WaitForSeconds(1.5f);
        sleep.OffDreams();
        yield return new WaitForSeconds(2);
        count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.CompareTag("Emilio") )
        {
            //Scream();
        }
        if(other.gameObject.name == "PunchBoss")
        {
            sanity -= 10;
            print("Pego boss");
        }
    }

    public void Scream()
    {
        Debug.Log("AAAAAAA me asuste");
        jumpScare.SetActive(true);
        bjumpScare = true;
        RecieveDamage(25);
    }

    public void Damage()
    {
        if (sanity <= 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            inv.SetActive(false);
            Debug.Log("Mike murio");
            death = true;
            Destroy(gameObject);
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
            healthSound.Stop();
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
           healthSound.Play();
            sanity += 0.1f;
            transparence = transparence + 0.001f;
            Debug.Log("que se empiece a blurrear la pantalla");
            Debug.Log("Recibir da?o por seg");
        }

        if(sanity <= 50)
        {
            //healthSound.Play();
            //Efecto de sue?o
            if (bloom.intensity.value <= 0.8f)
            {
                bloom.intensity.value += 0.01f;
            }
            

            Debug.Log("Tengo mucho sue?o");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, size);
    }
}
