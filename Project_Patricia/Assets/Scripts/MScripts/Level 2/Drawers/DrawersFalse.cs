using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawersFalse : MonoBehaviour
{
    [SerializeField] private Collider anim;
    [SerializeField] private TrashOn spoons, spoons2;
    [SerializeField] private PickableObject pick, pick2;
    [SerializeField] private SpoonsInteractionFinish spoon;

    public void Finish()
    {
        if (!spoon.accept)
        {
            anim.enabled = false;
            spoons.enabled = true;
            pick.enabled = true;
            pick.isPickable = true;
            spoons2.enabled = true;
            pick2.enabled = true;
            pick2.isPickable = true;
        }        
    }
}
