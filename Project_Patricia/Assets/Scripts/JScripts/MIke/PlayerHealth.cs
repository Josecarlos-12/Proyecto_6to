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

    public AudioSource healthSound, childScrean, bossAudio;

    [Header("SphereCast")]    
    public float size;
    public int count = 0;
    public int bossTouch = 0;
    [SerializeField] private SleepMode sleep;
    RaycastHit hit;

    [Header("Call Other Script")]
    [SerializeField] private MoveBoss moveBoss;

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
    }

    private void OnTriggerStay(Collider other)
    {
        if ( other.gameObject.CompareTag("Emilio") )
        {
            if (count < 3)
                count++;

            if (count == 1)
            {
                Scream();
                sleep.ModeDreams();
                StartCoroutine("OffDreams");
                childScrean.Play();
            }
        }
        if(other.gameObject.name == "PunchBoss")
        {
            //sanity -= 10;
            print("Pego boss");
        }
        if (other.gameObject.name == "BoosCon")
        {
            if (moveBoss.lifeLess)
            {
                if (bossTouch < 3)
                    bossTouch++;

                if (bossTouch == 1)
                {
                    bossAudio.Play();
                    sanity -= 10;
                    sleep.ModeDreams();
                    StartCoroutine("OffDreams");
                }
            }
            else
            {
                if (bossTouch < 3)
                    bossTouch++;

                if (bossTouch == 1)
                {
                    sanity -= 10;
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
        bossTouch= 0;
    }

    public void Scream()
    {
        Debug.Log("AAAAAAA me asuste");
        jumpScare.SetActive(true);
        bjumpScare = true;
        RecieveDamage(10);
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
            Destroy(player);
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
            Destroy(player);
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
            Destroy(player);
        }
        if (sanity > 101)
        {
           healthSound.Play();
            sanity += 0.1f;
            transparence = transparence + 0.001f;
            Debug.Log("que se empiece a blurrear la pantalla");
            Debug.Log("Recibir daño por seg");
        }

        if(sanity <= 50)
        {
            //healthSound.Play();
            //Efecto de sueño
            if (bloom.intensity.value <= 0.8f)
            {
                bloom.intensity.value += 0.01f;
            }
            

            Debug.Log("Tengo mucho sueño");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, size);
    }
}