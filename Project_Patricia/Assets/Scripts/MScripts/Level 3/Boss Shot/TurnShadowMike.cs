using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class TurnShadowMike : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject dialogue, pointChimney, battleMike;
    [SerializeField] private int count;

    [Header("Call Other Script")]
    [SerializeField] private PlayerFPSt move;
    [SerializeField] private PlayerCrouch crouch;
    [SerializeField] private Weapon weapon;

    [Header("Audio")]
    [SerializeField] private AudioSource shadowMike;
    [SerializeField] private AudioClip[] clip;


    void Start()
    {
        
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, pointChimney.transform.position) < 1)
        {
            if(count<3)
            count++;

            if (count < 3)
            {
                agent.enabled= false;
                anim.SetBool("Idle", true);
                StartCoroutine("Dialogue");
            }
        }   
    }

    public IEnumerator Dialogue()
    {
        shadowMike.clip = clip[0];
        shadowMike.Play();

        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "No pudiste salvarlos...";
        yield return new WaitForSeconds(2);
        dialogue.SetActive(false);
        anim.SetBool("Turn", true);
        anim.SetBool("Idle", false);
        anim.SetBool("Standing", false);
        anim.SetBool("Walk", false);
        yield return new WaitForSeconds(2);
        shadowMike.clip = clip[1];
        shadowMike.Play();

        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Y no lo harás ahora";
       

        yield return new WaitForSeconds(4);
        move.canWalk = true;
        crouch.crouchCan = true;
        weapon.shoot = true;
        weapon.shootTwo = true;
        dialogue.SetActive(false);
        battleMike.SetActive(true);
        Destroy(gameObject.transform.parent.parent.gameObject);
        print("En ese momento se la saca y comienza la batalla final");
    }
}
