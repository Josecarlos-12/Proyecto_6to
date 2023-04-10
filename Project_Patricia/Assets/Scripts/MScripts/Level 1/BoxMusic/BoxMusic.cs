using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxMusic : MonoBehaviour
{
    [SerializeField] private Collider col;
    [SerializeField] private GameObject text, texMes, objSing;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private bool into, accept;
    [SerializeField] private StrongBox pass;
    [SerializeField] private PickableObject pick;
    [SerializeField] private int count;


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
        yield return new WaitForSeconds(2);
        texMes.SetActive(false);
    }

    public IEnumerator Dialogue()
    {
        texMes.SetActive(true);   
        textMeshPro.text = "Mike Schmith: Ahora esto.";
        yield return new WaitForSeconds(1);
        texMes.SetActive(false);
        accept = true;
        into = true;
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

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(false);
            into = false;
        }
    }
}
