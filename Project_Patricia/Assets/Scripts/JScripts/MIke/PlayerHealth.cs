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

    [Range(0,100)]
    public float sanity = 100f;
    public float sanityMax = 100;

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

    public AudioSource healthSound, childScrean, bossAudio, mikeHurt;

    [Header("SphereCast")]    
    public float size;
    public int count = 0;
    public int bossTouch = 0, catPunch;
    [SerializeField] private SleepMode sleep;
    RaycastHit hit;

    [Header("Call Other Script")]
    [SerializeField] private MoveBoss moveBoss;
    [SerializeField] private PlayerFPSt playerMove;

    [Header("Life Text")]
    [SerializeField] private Text textNormal;

    [Header("Game Over")]
    [SerializeField] private GameObject camGameOver;
    [SerializeField] private GameObject panelGameOver;

    [Header("Life Regeneration")]
    public bool punch;
    [SerializeField] private float time, maxtime;
    public bool bulletBoos;

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

        LifeActu();
        LifeRegeneration();
       // PanelDmg();
       //Damage();
    }

    public void LifeActu()
    {
        textNormal.text = sanity.ToString("0");
    }

    private void OnTriggerStay(Collider other)
    {
        if ( other.gameObject.CompareTag("Emilio") )
        {
            if (count < 3)
                count++;

            if (count == 1)
            {
                punch = true;
                mikeHurt.Play();
                Scream();
                sleep.ModeDreams();
                StartCoroutine("OffDreams");
                //childScrean.Play();
            }
        }

        if (other.gameObject.name== "ReturnEnemy")
        {

        }
        
        if (other.gameObject.name == "BossCon")
        {
                if (bossTouch < 3)
                    bossTouch++;

                if (bossTouch == 1)
                {
                    punch = true;
                    //bossAudio.Play();
                    sanity -= 10;
                    sleep.ModeDreams();
                    StartCoroutine("OffDreams");
                }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PunchBoss")
        {
            mikeHurt.Play();
            sanity -= 5;
            DamageNormal();
        }

        if(other.gameObject.name == "BulletBoss")
        {
            if (bossTouch < 3)
                bossTouch++;

            if (bossTouch == 1)
            {
                print("Bullet");
                bulletBoos = true;
                punch = true;
                mikeHurt.Play();
                sanity -= 10;
                sleep.ModeDreams();
                StartCoroutine("OffDreams");
            }
        }
    }

    public void DamageNormal()
    {
        
        sleep.ModeDreams();
    }
    

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PunchBoss")
        {
            StartCoroutine("OffDreams");
        }

        if (other.gameObject.name == "ReturnEnemy")
        {

        }
    }

    

    public void LifeRegeneration()
    {
        if (sanity < 50 && !punch)
        {
            time += Time.deltaTime;
            if (time >= maxtime)
            {
                time = 0;
                if(sanity < 50)
                {
                    sanity += 5;
                    if (sanity > 50)
                    {
                        sanity = 50;
                    }
                }                
            }
        }
        if(sanity < 50 && punch)
        {
            time= 0;
        }
    }

    public IEnumerator OffDreams()
    {
        catPunch = 0;
        yield return new WaitForSeconds(1.5f);
        sleep.OffDreams();
        punch= false;
        yield return new WaitForSeconds(2);
        count = 0;
        bossTouch= 0;
        print("Off");
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
            //Destroy(player);
            GameOver();
        }
    }

    public void GameOver()
    {
        camGameOver.SetActive(true);
        panelGameOver.SetActive(true);
        camGameOver.transform.position = player.transform.position;
        player.SetActive(false);        
         
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
            //Destroy(player);
            GameOver();
        }
        if ( sanity > 100 )
        {
            healthSound.Stop();
            sanity = 100;
        }      
    }

    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, size);
    }
}