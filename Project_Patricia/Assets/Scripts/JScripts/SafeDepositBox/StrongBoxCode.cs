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
    public GameObject cam, prota;
    public bool touch;
    public Animator animObjects;
    public GameObject aim;

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
            aim.SetActive(false);
            animObjects.SetBool("On", true);
            inside = false;
            //coll.enabled = false;
            eText.SetActive(false);
            anim.SetBool("On", false);
            cam.SetActive(true);
            prota.SetActive(false);
            print("Se Abrio");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            StartCoroutine("On");
        }

        if(touch && Input.GetKeyDown(KeyCode.E))
        {
            touch = false;
            cam.SetActive(false);
            prota.SetActive(true); print("Se choca");
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public IEnumerator On()
    {
        yield return new WaitForSeconds(0.5f);
        touch = true;
    }
    private void OnTriggerEnter(Collider other)
    {
       
    }

    private void OnTriggerStay(Collider other)
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
