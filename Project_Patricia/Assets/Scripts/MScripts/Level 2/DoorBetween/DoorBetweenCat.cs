using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBetweenCat : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public bool into, op;
    public bool open, close;
    [SerializeField] private int count;
    [SerializeField] private AudioSource door;
    [SerializeField] private AudioClip[] clip;

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
                    door.clip = clip[0];
                    door.Play();
                }
                if (!op && open)
                {
                    op = true;
                    anim.SetBool("Between", false);
                    anim.SetBool("Open", true);
                    close = false;
                    door.clip = clip[1];
                    door.Play();
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
