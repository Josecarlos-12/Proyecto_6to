using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
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
    [SerializeField] private TasksUILevel2 task;
    [SerializeField] private GameObject taskUI;

    [Header("TutoRifle")]
    [SerializeField] GameObject tutoRifle;
    [SerializeField] AnimTrue aniRifle;
    [SerializeField] Animator animationRifle;

    [Header("TutoReloading")]
    [SerializeField] GameObject tutoReloading;
    [SerializeField] AnimTrue animReloading;
    [SerializeField] Animator animatorReloading;

    [Header("Change Rifle")]
    [SerializeField] private GameObject container;
    [SerializeField] private GameObject spotL, Lanter, pointL, lanterAll;
    [SerializeField] private AudioSource strainCharlie;

    void Update()
    {
        if (grab && into && Input.GetKeyDown(KeyCode.E))
        {
            lanterAll.SetActive(false);
            spotL.SetActive(true);

            wayPoint.SetActive(true);
            inve.rifle = true;
            inve.spriteRifle = true;
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
            //cambia la posicion de la linterna
            //container.transform.parent = rifle.transform;
            //lanter.SetActive(false);
            //container.transform.position = new Vector3(0.699f, -0.309f, 0.179f);
            //container.transform.rotation = Quaternion.Euler(0f, -12.99f, 0f);
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
        strainCharlie.Play();
        shadowBattle.SetActive(true);
        text.SetActive(false);
        yield return new WaitForSeconds(2);
        task.task = "Go back home";
        task.go = true;
        taskUI.SetActive(true);

        audioMike.clip = clip[1];
        audioMike.Play();
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Tal vez Cat ya haya regresado y pueda ayudarme a buscarlo";
        yield return new WaitForSeconds(5);
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
