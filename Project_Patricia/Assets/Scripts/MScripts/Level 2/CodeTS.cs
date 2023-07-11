using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeTS : MonoBehaviour
{
    [SerializeField] private PlayerCrouch crouch;
    [SerializeField] private PlayerFPSt move;
    [SerializeField] private CameraLook cam;
    [SerializeField] private int count;
    [SerializeField] private GameObject panel, note;

    void Start()
    {
        crouch.crouchCan = false;
        move.canWalk = false;
        cam.moveCamera = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            count++;

            if (count == 1)
            {
                panel.SetActive(true);
            }
            if(count== 2)
            {
                panel.SetActive(false);
            }
            if (count == 3)
            {
                note.SetActive(false);
                crouch.crouchCan = true;
                move.canWalk = true;
                cam.moveCamera = true;
            }
        }
    }
}
