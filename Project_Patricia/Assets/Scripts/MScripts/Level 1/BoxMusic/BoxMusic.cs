using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxMusic : MonoBehaviour
{
    [SerializeField] private Collider col;
    [SerializeField] private GameObject text, texMes, objSing;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private bool into, intoTrue, accept;
    [SerializeField] private StrongBox pass;
    [SerializeField] private PickableObject pick;
    [SerializeField] private int count;

    [SerializeField] private AudioSource audioMike;
    [SerializeField] private AudioClip[] clip;

    void Update()
    {
        if (into && accept)
        {
            text.SetActive(true);
        }

        if (into && Input.GetKeyDown(KeyCode.E) && pass.pass==true)
        {
            pick.isPickable= true;
            text.SetActive(false);
            objSing.SetActive(true);
            into = false;
            col.enabled = false;
            StartCoroutine("Interaction");
        }
    }

    public IEnumerator Interaction()
    {
        texMes.SetActive(true);
        textMeshPro.text = "Mike Schmith: Hmmm qué raro... ¿Qué es lo que estará fallando?";
        audioMike.clip = clip[1];
        audioMike.Play();
        yield return new WaitForSeconds(5);
        audioMike.clip = clip[2];
        audioMike.Play();
        textMeshPro.text = "Mike Schmith: Hmmm hay piezas que fallan, iré a ver si tengo en mi estudio algo que pueda servirme.";
        yield return new WaitForSeconds(5);
        texMes.SetActive(false);
    }

    public IEnumerator Dialogue()
    {
        texMes.SetActive(true);   
        textMeshPro.text = "Mike Schmith: Ahora esto.";
        audioMike.clip = clip[0];
        audioMike.Play();
        yield return new WaitForSeconds(1);
        texMes.SetActive(false);
        accept = true;
        intoTrue = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (pass.pass == true)
            {                        
                
                if (count<3)
                count++;

                if (count == 1)
                {
                    StartCoroutine("Dialogue");
                }
            }

            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            if (intoTrue)
            {
                into = true;
            }


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
