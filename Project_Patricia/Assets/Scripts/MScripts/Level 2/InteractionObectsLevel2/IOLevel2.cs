using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IOLevel2 : MonoBehaviour
{
    [SerializeField] Collider col;

    [SerializeField] private GameObject text;
    [SerializeField] private bool into;
    [SerializeField] private Collider coll, collShiny;
    [SerializeField] private Animator cookingShiny;

    [Header("Call Other Script")]
    [SerializeField] private OpenDoorBathroom active;
    [SerializeField] private ShinyLevel2 shiny;

    [Header("Animation")]
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject prota;
    [SerializeField] private Animator animCooking;

    [Header("Dialogue")]
    [SerializeField] private GameObject textDialogue;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && into)
        {
            col.enabled = true;
            //animCooking.SetBool("On", true);
            cam.SetActive(true);
            prota.SetActive(false);
            active.bActive = false;
            coll.enabled = false;
            text.SetActive(false);
            into = false;
            collShiny.enabled = false;
            cookingShiny.SetBool("Anim", true);
            StartCoroutine("AnimFalse");
        }   
    }

    public IEnumerator AnimFalse()
    {
        yield return new WaitForSeconds(2);
        textDialogue.SetActive(true);
        textDialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Hmmm huele muy bien y se ve rico";
        yield return new WaitForSeconds(2.30f);
        shiny.on = true;
        textDialogue.SetActive(false);
        prota.SetActive(true);
        cam.SetActive(false);
        yield return new WaitForSeconds(1f);
        textDialogue.SetActive(true);
        textDialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Bien... pondré la mesa";
        yield return new WaitForSeconds(2f);
        textDialogue.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (active.bActive)
            {
                text.SetActive(true);
                into =true; 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(false);
            into = false;
        }
    }

}
