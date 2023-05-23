using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBetweenCat : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public bool into, op;
    public bool open, close;
    [SerializeField] private int count;


    private void Start()
    {
        close = false;
        open = true;
    }

    void Update()
    {
        Door();
    }

    public void Door()
    {
        if (into)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (op && close)
                {
                    op = false;
                    anim.SetBool("Open", false);
                    open = false;
                }
                if (!op && open)
                {
                    op = true;
                    anim.SetBool("Between", false);
                    anim.SetBool("Open", true);
                    close = false;

                }

            }
        }

    }

    public void Open()
    {
        open = true;
        close = false;
    }

    public void Close()
    {
        close = true;
        open = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = false;
        }
    }
}
