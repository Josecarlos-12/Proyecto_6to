using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxMusic : MonoBehaviour
{
    [SerializeField] private Collider col;
    [SerializeField] private GameObject text, texMes, objSing;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private bool into;
    [SerializeField] private StrongBox pass;
    [SerializeField] private PickableObject pick;


    void Update()
    {
        if (into && Input.GetKeyDown(KeyCode.E) && pass.pass==true)
        {
            pick.isPickable= true;
            text.SetActive(false);
            objSing.SetActive(true);
            into = false;
            col.enabled = false;
            StartCoroutine("Dialogue");
        }
    }

    public IEnumerator Dialogue()
    {
        texMes.SetActive(true);   
        textMeshPro.text = "Texto sa";
        yield return new WaitForSeconds(1);
        texMes.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (pass.pass == true)
            {
                text.SetActive(true);
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
