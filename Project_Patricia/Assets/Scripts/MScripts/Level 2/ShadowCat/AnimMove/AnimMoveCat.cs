using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimMoveCat : MonoBehaviour
{
    [SerializeField] private Animator anim, thisAnim;
    [SerializeField] private GameObject dialogue, prota, cam;
    [SerializeField] private GameObject lanterGod, lanterBad, LanterPlayer;
    [SerializeField] private Lantern lanter;
    [SerializeField] private Light sun, ligthLanter;



    public IEnumerator DialogueInit()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Qué fue eso?";
        yield return new WaitForSeconds(2);
        dialogue.SetActive(false);
    }

    public IEnumerator DialogueFinish()
    {
        sun.intensity = 9;

        //Mathf.Lerp(242.1584f, 7, 0.5f);

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
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Tengo que encontrar a Cat, quizá esté en peligro";
        yield return new WaitForSeconds(3);
        ligthLanter.enabled = true;
        dialogue.SetActive(false);
    }

    public void CursorMouse()
    {
        sun.intensity= 20;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Walk()
    {
        anim.SetBool("Walk", true);
    }

    public void Flash()
    {
        anim.SetBool("Flash", true);
    }

    public void Run()
    {
        anim.SetBool("Run", true);
    }
}
