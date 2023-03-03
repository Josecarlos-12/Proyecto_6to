using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool into;
    public bool open;
    public GameObject text;
    public Animator anim;
    public AudioSource openDoor;
    public AudioSource closeDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            open = !open;
            if (open)
            {
                openDoor.Play();
                anim.SetBool("open", true);
            }
            else
            {
                closeDoor.Play();
                anim.SetBool("open", false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(true);
            into = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(false);
            into = false;
        }
    }
}
