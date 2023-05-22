using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpoonsInteractionFinish : MonoBehaviour
{
    [SerializeField] private TrashOn trashOne, trashTwo, trashDishes;
    [SerializeField] private Collider coll;
    public bool accept;
    [SerializeField] private int count, count2;
    [SerializeField] private GameObject colliderKitchen;    
    [SerializeField] private GameObject textRepeat;
    [SerializeField] private ShinyLevel2 shiny;
    [SerializeField] private GameObject textReapeat;

    [SerializeField] private PickableObject pickableObject, pickableObject2;
    [SerializeField] private TrashOn trash, trash2;

    [SerializeField] private ShinyLevel2 glasses, glasses2;

    [Header("Dialogue")]
    [SerializeField] private GameObject textDialogue;

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

            if(count<3)
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
    }

    public IEnumerator Dialogue()
    {
        textDialogue.SetActive(true);
        textDialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Bien, ahora siguen los platos";
        yield return new WaitForSeconds(2);
        textDialogue.SetActive(false);
    }
}
