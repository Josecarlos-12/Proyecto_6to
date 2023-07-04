using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class CatCallMike : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;
    [SerializeField] private Collider thisCol;
    [SerializeField] private GameObject mikeCatRoom;

    [Header("Hectic")]
    [SerializeField] private AudioSource hectic;
    [SerializeField] private GameObject prota, point, eyes, shadowMike;
    [SerializeField] private Animator animEyes, animShadowMike;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform pointChimney;

    [Header("Call Other Script")]
    [SerializeField] private PlayerFPSt move;
    [SerializeField] private PlayerCrouch crouch;
    [SerializeField] private Weapon weapon;
    [SerializeField] private CameraLook look;

    [Header("Audios")]
    [SerializeField] private AudioSource shadowMikeAudio;
    [SerializeField] private AudioClip[] clip;

    [SerializeField] private WakingUpMode waking;

    public enum Touch
    {
        charlie, mikeCatRoom, PentHouse
    }
    public Touch touch;

    private void Awake()
    {
        
        eyes.SetActive(true);
        animEyes.SetBool("Open", true);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible= false;
        StartCoroutine("PentHouse");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (touch)
            {
                case Touch.charlie:
                    thisCol.enabled = false;
                    StartCoroutine("Dialogue");
                    break; 
                case Touch.mikeCatRoom:
                    thisCol.enabled = false;
                    StartCoroutine("MikePentHouse");
                    break;
                case Touch.PentHouse:
                    thisCol.enabled = false;
                    StartCoroutine("PentHouse");
                    break;
            }
        }
    }

    public IEnumerator Dialogue()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Papaaaaaa! ¡Tengo miedooo!";
        yield return new WaitForSeconds(3);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: ¡Miiiiiike!";
        yield return new WaitForSeconds(2);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: ¡Te necesitooooo!";
        yield return new WaitForSeconds(3);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Caaaat!";
        yield return new WaitForSeconds(2);
        mikeCatRoom.SetActive(true);
        dialogue.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public IEnumerator MikePentHouse()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Papiiiiiii!";
        yield return new WaitForSeconds(2);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Por favor ayudaaaa!";
        yield return new WaitForSeconds(3);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Charlie!";
        mikeCatRoom.SetActive(true);
        dialogue.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public IEnumerator PentHouse()
    {
        look.moveCamera = false;
        move.canWalk = false;
        crouch.crouchCan = false;
        weapon.shoot = false;
        weapon.shootTwo = false;
        yield return new WaitForSeconds(0.4f);
        look.moveCamera = false;
        waking.WakingOn();
        yield return new WaitForSeconds(2);
        
        
        
        shadowMike.SetActive(true);
        
        
        look.xRotation = 0;
        // Abre los Ojos
        yield return new WaitForSeconds(2);
        look.moveCamera = true;
        shadowMikeAudio.clip = clip[0];
        shadowMikeAudio.Play();
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "¿Escuchas sus voces?";
        yield return new WaitForSeconds(2);
        shadowMikeAudio.clip = clip[1];
        shadowMikeAudio.Play();

        dialogue.GetComponent<TextMeshProUGUI>().text = "Igual yo...";
        yield return new WaitForSeconds(2);
        shadowMikeAudio.clip = clip[2];
        shadowMikeAudio.Play();

        eyes.SetActive(false);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Todo el tiempo...";
        yield return new WaitForSeconds(2);
        animShadowMike.SetBool("Standing", true);
        dialogue.SetActive(false);
        yield return new WaitForSeconds(2.8f);
        animShadowMike.SetBool("Walk", true);
        agent.destination = pointChimney.position;
        yield return new WaitForSeconds(0.6f);
    }
}
