using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonsInteractionFinish : MonoBehaviour
{
    [SerializeField] private TrashOn trashOne, trashTwo;
    [SerializeField] private Collider coll;
    public bool accept;
    [SerializeField] private int count;
    [SerializeField] private GameObject colliderKitchen;


    void Update()
    {
        if(trashOne.into && trashTwo.into)
        {
            if(count<3)
            count++;

            if (count == 1)
            {
                coll.enabled = true;
                accept = true;
                colliderKitchen.SetActive(true);
                print("Termino");
            }
        }
    }
}
