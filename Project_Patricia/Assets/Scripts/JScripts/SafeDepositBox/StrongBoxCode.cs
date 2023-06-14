using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongBoxCode : MonoBehaviour
{
    public bool codeOne;
    public bool codeTwo;
    public bool codeThree;
    public bool inside;

    public GameObject eText;
    public Animator anim;
    public int counter;
    public Collider coll;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (codeOne && codeTwo && codeThree)
        {
            if(counter< 3)
            counter++;
            if(counter == 1)
            {
                anim.SetBool("On", true);
                coll.enabled = true;
            }

        }

        if(inside == true && Input.GetKeyDown(KeyCode.E))
        {
            inside = false;
            coll.enabled = false;
            eText.SetActive(false);
            anim.SetBool("On", false); 
            print("Se Abrio");
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Player"))
        {
            eText.SetActive(true);
            inside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            eText.SetActive(false);
            inside = false; 
        }
    }
}
