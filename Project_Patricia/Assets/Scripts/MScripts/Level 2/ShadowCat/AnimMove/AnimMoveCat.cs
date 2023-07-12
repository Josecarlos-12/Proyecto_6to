using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering.PostProcessing;

public class AnimMoveCat : MonoBehaviour
{
    [SerializeField] private Animator anim, thisAnim;
    [SerializeField] private GameObject dialogue, prota, cam, hud;
    [SerializeField] private GameObject lanterGod, lanterBad, LanterPlayer;
    [SerializeField] private Lantern lanter;
    [SerializeField] private Light sun, ligthLanter;
    [SerializeField] private GameObject cat;

    [SerializeField] private AudioSource mike;
    [SerializeField] private AudioClip[] clip;

    [SerializeField] private AudioSource punch;
    [SerializeField] private AudioSource bodyFall, lanterFall;
    [SerializeField] private AudioSource soundFollow, scare;

    [SerializeField] private Volume volu;
    [SerializeField] IndirectLightingController indi;

    void Start()
    {
        //cam = GetComponent<PlayerCamera>();
        volu.profile.TryGet(out IndirectLightingController iD);
        indi = iD;
    }

    public IEnumerator DialogueInit()
    {
        mike.clip = clip[0];
        mike.Play();

        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Qué fue eso?";
        yield return new WaitForSeconds(2);
        dialogue.SetActive(false);
    }

    public IEnumerator DialogueFinish()
    {
        //sun.intensity = 9;

        //Mathf.Lerp(242.1584f, 7, 0.5f);
        hud.SetActive(true);
        lanterGod.SetActive(false);
        lanterBad.SetActive(true);
        LanterPlayer.SetActive(false);
        lanter.lanter = Lantern.Lanter.bad;
        prota.transform.position = cam.transform.position;
        prota.transform.rotation = Quaternion.Euler(transform.rotation.x, 90, transform.rotation.z);
        prota.SetActive(true);
        cam.SetActive(false);
        thisAnim.enabled = false;
        yield return new WaitForSeconds(1);
        mike.clip = clip[1];
        mike.Play();

        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Tengo que encontrar a Cat, quizá esté en peligro";
        yield return new WaitForSeconds(3);
        ligthLanter.enabled = true;
        dialogue.SetActive(false);
        yield return new WaitForSeconds(2);
        //cat.SetActive(true);
    }

    public void LanterFall()
    {
        lanterFall.Play();
    }

    public void CursorMouse()
    {
        soundFollow.Play();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        indi.indirectDiffuseLightingMultiplier.value = 0.7f;
        indi.reflectionLightingMultiplier.value = 0.5f;
        sun.intensity = 5f;
        print(sun.intensity);
    }

    public void BodyFall()
    {
        bodyFall.Play();
    }

    public void PunchSound()
    {
        punch.Play();
    }

    public void Walk()
    {        
        anim.SetBool("Walk", true);
    }

    public void Flash()
    {
        scare.Play();
        anim.SetBool("Flash", true);
    }

    public void Run()
    {
        anim.SetBool("Run", true);
    }
}
