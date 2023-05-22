using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawersFalse : MonoBehaviour
{
    [SerializeField] private Collider anim;
    [SerializeField] private TrashOn spoons, spoons2;
    [SerializeField] private PickableObject pick, pick2;
    [SerializeField] private SpoonsInteractionFinish spoon;
    [SerializeField] private IOLevel2 drawer;
    [SerializeField] private int count;
    [SerializeField] private DrawersOpen open;

    private void Update()
    {
        if (spoon != null)
        {
            if (!spoon.accept && drawer.openDrawer && open.open)
            {
                if(count<3)
                count++;

                if (count == 1)
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
    }

    public void Finish()
    {
        /*if (spoon != null)
        {
            if (!spoon.accept && drawer.openDrawer)
            {
                anim.enabled = false;
                spoons.enabled = true;
                pick.enabled = true;
                pick.isPickable = true;
                spoons2.enabled = true;
                pick2.enabled = true;
                pick2.isPickable = true;
            }
        }*/
    }
}
