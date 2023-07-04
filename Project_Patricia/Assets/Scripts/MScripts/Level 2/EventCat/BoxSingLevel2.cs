using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxSingLevel2 : MonoBehaviour
{
    [SerializeField] private AudioSource boxSing;
    public bool bBox, finish, into, life;
    [SerializeField] private GameObject eText;
    [SerializeField] private Collider col;
    [SerializeField] private float time, maxTime;
    [SerializeField] private float timeLife, maxTimeLife;
    [SerializeField] private PlayerHealth healtf;
    [SerializeField] private SanityLevel sanity;
    [SerializeField] private Animator animBox;
    [SerializeField] private LightInRoom lightRoom;
    [SerializeField] private int count;

    private void Update()
    {
        if (into && Input.GetKeyDown(KeyCode.E))
        {
            animBox.SetBool("Move", true);
            healtf.punch = true;
            sanity.lightLife = SanityLevel.LightLife.None;
            bBox= true;
            into = false;
            col.enabled = false;
            eText.SetActive(false);
            boxSing.Play();
            healtf.sleep.ModeDreams();
            StartCoroutine("BoxSing");
        }
        if(finish && boxSing.volume > 0.02f)
        {
            time += Time.deltaTime;
            if(time > maxTime)
            {
                time = 0;
                boxSing.volume -= 0.03f;
            }
        }
        if(boxSing.volume < 0.037f) 
        {
            boxSing.Stop();
        }

        if (!life && bBox)
        {
            timeLife += Time.deltaTime;
            if(timeLife>maxTimeLife)
            {
                timeLife = 0;
                healtf.sanity -= 5;
            }
        }

        if (lightRoom.finish ==true)
        {
            if(count<3)
            count++;

            if (count == 1)
            {
                StopCoroutine("BoxSing");
                StartCoroutine("DestroyObject");
            }
        }
    }

    public IEnumerator BoxSing()
    {
        yield return new WaitForSeconds(13);
        finish = true;
        yield return new WaitForSeconds(12);
        print("Paso 15 se");
        animBox.SetBool("Move", false);
        healtf.punch = false;
        sanity.lightLife = SanityLevel.LightLife.less;        
        life = true;
        sanity.into = false;
        healtf.StartCoroutine("OffDreams");
        bBox = false;
        Destroy(gameObject);
    }

    public IEnumerator DestroyObject()
    {
        finish = true;
        print("Paso 15 se");
        animBox.SetBool("Move", false);
        healtf.punch = false;
        sanity.lightLife = SanityLevel.LightLife.less;
        life = true;
        sanity.into = false;
        healtf.StartCoroutine("OffDreams");
        bBox = false;
        yield return new WaitForSeconds(5);
        healtf.StartCoroutine("OffDreams");
        yield return new WaitForSeconds(15);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            into = true;
            eText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = false;
            eText.SetActive(false);
        }
    }

}
