using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpoonsInteractionFinish : MonoBehaviour
{
    [SerializeField] private TrashOn trashOne, trashTwo, trashDishes, trashGlass, trashGlasses2, wine;
    [SerializeField] private Collider coll;
    public bool accept;
    [SerializeField] private int count, count2, count3, count4;
    [SerializeField] private GameObject colliderKitchen;
    [SerializeField] private GameObject textRepeat;
    [SerializeField] private ShinyLevel2 shiny;
    [SerializeField] private GameObject textReapeat, AlarmOn;

    [SerializeField] private PickableObject pickableObject, pickableObject2;
    [SerializeField] private TrashOn trash, trash2;

    [SerializeField] private ShinyLevel2 glasses, glasses2;
    [SerializeField] private GameObject flower;
    [SerializeField] private Animator animFlower;


    [Header("Dialogue")]
    [SerializeField] private GameObject textDialogue;

    [Header("Audio")]
    [SerializeField] private AudioSource mike;
    [SerializeField] private AudioClip[] clip;

    void Update()
    {
        if(trashOne.into && trashTwo.into)
        {
            if(count<3)
            count++;

            if (count == 1)
            {
                textRepeat.SetActive(false);
                coll.enabled = true;
                accept = true;                
                //Activa el collider de la cocina que activa la alarma
                colliderKitchen.SetActive(true);
                StartCoroutine("Dialogue");
                print("Termino");
                shiny.on = true;
            }
        }

        if (trashDishes.into)
        {

            if(count2<3)
            count2++;

            if (count2 == 1)
            {
                textReapeat.SetActive(false);
                textReapeat.GetComponent<RepeatText>().sText = "Mike Schmith: Faltan un par de vasos"; 
                textReapeat.SetActive(true);
                trash.enabled = true;
                pickableObject.enabled = true;
                pickableObject.isPickable = true;

                trash2.enabled = true;
                pickableObject2.enabled = true;
                pickableObject2.isPickable = true;

                glasses.on=true;
                glasses2.on = true;
            }
        }

        if(trashGlass.into && trashGlasses2.into)
        {
            if(count3< 3)
            count3++;

            if (count3 == 1)
            {
                AlarmOn.SetActive(true);
                textReapeat.SetActive(false);
                StartCoroutine("DialogueGlass");
            }
        }

        if (wine.into)
        {
            if(count4< 3)
               count4++;

            if (count4 == 1)
            {
                StartCoroutine("DialogueWine");
            }
        }
    }

    public IEnumerator DialogueGlass()
    {
        textDialogue.SetActive(true);
        textDialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Un vino sería fabuloso para esta cena";
        yield return new WaitForSeconds(3);
        textDialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Traeré el Bricco Magno que queda";
        yield return new WaitForSeconds(3);
        textDialogue.SetActive(false);
    }

    public IEnumerator Dialogue()
    {
        textDialogue.SetActive(true);
        textDialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Bien, ahora siguen los platos";
        yield return new WaitForSeconds(2);
        textDialogue.SetActive(false);
    }

    public IEnumerator DialogueWine()
    {
        mike.clip = clip[0];
        mike.Play();

        textDialogue.SetActive(true);
        textDialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Uhmm, lo único que faltaría es...";
        yield return new WaitForSeconds(2);
        textDialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Una flor para la mesa";
        yield return new WaitForSeconds(2);
        mike.clip = clip[1];
        mike.Play();

        textDialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: A Catelyn le encanta las margaritas";
        yield return new WaitForSeconds(3);
        mike.clip = clip[2];
        mike.Play();

        textDialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Creo haber visto crecer algunas cerca de la entrada";
        yield return new WaitForSeconds(3);
        flower.SetActive(true);
        animFlower.enabled= true;
        textDialogue.SetActive(false);
    }
}
