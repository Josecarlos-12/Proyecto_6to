using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShedCat : MonoBehaviour
{
    [SerializeField] private GameObject dialogue, rifleWeapon;
    [SerializeField] private Collider col;
    [SerializeField] private Animator animRifle, animChain;
    [SerializeField] private int count;

    [Header("Call Other Script")]
    [SerializeField] private Inventary inventory;
    [SerializeField] private Weapon weapon;

    [SerializeField] private AudioSource mike;
    [SerializeField] private AudioClip[] clip;

    [SerializeField] private GameObject repeat;

    private void Update()
    {
        if (rifleWeapon.activeInHierarchy)
        {
            if (count < 3)
                count++;

            if (count == 1)
            {
                animRifle.SetBool("Change", false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            repeat.SetActive(false);

            col.enabled = false;
            StartCoroutine("Dialogue");
        }
    }

    public IEnumerator Dialogue()
    {
        mike.clip = clip[0];
        mike.Play();
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Sigue con el candado...";
        yield return new WaitForSeconds(3);
        mike.clip = clip[1];
        mike.Play();
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Se ve viejo y fr�gil";
          
        inventory.spriteRifle = true;
        inventory.rifle = true;
        inventory.bPills = false;
        inventory.bKeyComfi = false;        
        weapon.shoot= true;
        weapon.shootTwo= true;
        yield return new WaitForSeconds(0.4f);
        animRifle.SetBool("Change", true);
        animChain.SetBool("On", true);
        yield return new WaitForSeconds(2);
        dialogue.SetActive(false);        
    }

}
