using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Head head;
    [SerializeField] private bool press;
    public bool crouch;
    public bool crouchCan;

    // Start is called before the first frame update
    void Start()
    {
     anim=GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        Crouch();
    }

    public void Crouch()
    {
        if(crouchCan)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                press = true;
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                press = false;
            }

            if (press || head.head)
            {
                crouch = true;
                anim.SetBool("Crouch", true);
            }
            else if (!press && !head.head)
            {
                crouch = false;
                anim.SetBool("Crouch", false);
            }
        }        
    }
}
