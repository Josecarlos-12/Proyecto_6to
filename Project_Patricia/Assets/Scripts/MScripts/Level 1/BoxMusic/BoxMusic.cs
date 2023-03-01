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


    void Update()
    {
        if (into && Input.GetKeyDown(KeyCode.E))
        {
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
