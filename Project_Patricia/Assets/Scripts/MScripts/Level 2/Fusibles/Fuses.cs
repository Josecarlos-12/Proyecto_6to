using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuses : MonoBehaviour
{
    [SerializeField] private bool into, on;
    [SerializeField] private Animator anim;
    [SerializeField] private bool open, close;
    public bool touch;

    private void Start()
    {
        close= true;
        open= false;
        on = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && into)
        {
            touch= true;

            if (on && close)
            {
                close= false;
                anim.SetBool("On", true);
                StartCoroutine("Close");
            }
            else if (!on && open)
            {
                open= false;
                anim.SetBool("On", false);
                StartCoroutine("Open");
            }
        }
    }

    public IEnumerator Close()
    {
        yield return new WaitForSeconds(0.30f);
        open = true;
        close= false;
        on = false;
    }

    public IEnumerator Open()
    {
        yield return new WaitForSeconds(0.30f);
        open = false;
        close = true;
        on = true;
    }

    private void OnMouseOver()
    {
        into = true;
    }

    private void OnMouseExit()
    {
        into = false;
    }
}
