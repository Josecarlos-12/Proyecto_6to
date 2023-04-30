using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrabRifleSounds : MonoBehaviour
{
    public bool grab, into;
    [SerializeField] private GameObject text, pressE, wayPoint, charlie;
    [SerializeField] private Collider col;
    [SerializeField] private AudioSource[] audioRifle;
    [SerializeField] private MeshRenderer mesh;


    [SerializeField] private GameObject shadowBattle;

    [SerializeField, Header("Call Other Script")] private Weapon weapon;
    [SerializeField] private Inventary inve;
    [SerializeField] private AudioSource audioMike;
    [SerializeField] private AudioClip[] clip;

    [Header("TutoRifle")]
    [SerializeField] GameObject tutoRifle;
    [SerializeField] AnimTrue aniRifle;
    [SerializeField] Animator animationRifle;

    [Header("TutoReloading")]
    [SerializeField] GameObject tutoReloading;
    [SerializeField] AnimTrue animReloading;
    [SerializeField] Animator animatorReloading;

    void Update()
    {
        if (grab && into && Input.GetKeyDown(KeyCode.E))
        {
            wayPoint.SetActive(true);
            inve.rifle = true;
            pressE.SetActive(false);
            weapon.shootTwo = true;

            mesh.enabled= false;
            into = false;
            col.enabled = false;
            StartCoroutine("Dialogue");
            Destroy(charlie);
            for (int i = 0; i < audioRifle.Length; i++)
            {
                Destroy(audioRifle[i]);
            }

        }

        MouseClick();
        Reloading();
    }

    public IEnumerator Dialogue()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Te encontraré...";
        audioMike.clip = clip[0];
        audioMike.Play();
        yield return new WaitForSeconds(2);
        tutoRifle.SetActive(true);
        yield return new WaitForSeconds(3);
        shadowBattle.SetActive(true);
        text.SetActive(false);
        
    }

    public void MouseClick()
    {
        if(aniRifle.finish && Input.GetMouseButtonDown(0))
        {
            aniRifle.finish= false;
            animationRifle.SetBool("Exit", true);
            StartCoroutine("PanelRifle");
        }
    }

    public IEnumerator PanelRifle()
    {
        yield return new WaitForSeconds(1.3f);
        tutoRifle.SetActive(false);
        yield return new WaitForSeconds(5f);
        tutoReloading.SetActive(true);
        //Destroy(gameObject);
    }

    public void Reloading()
    {
        if(animReloading.finish && Input.GetKeyDown(KeyCode.R))
        {
            animReloading.finish = false;
            animatorReloading.SetBool("Exit", true);
            StartCoroutine("ReloadingCorutine");
        }
    }

    public IEnumerator ReloadingCorutine()
    {
        yield return new WaitForSeconds(1.3f);
        tutoReloading.SetActive(false);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (grab)
            {
                pressE.SetActive(true);
                into = true;
            }            
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
                pressE.SetActive(false);
                into = false;
            
        }

    }
}
