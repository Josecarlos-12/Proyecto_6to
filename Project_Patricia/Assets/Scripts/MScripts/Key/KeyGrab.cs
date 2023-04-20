using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyGrab : MonoBehaviour
{
    [SerializeField] GameObject text, dialogue, containerKey;
    [SerializeField] bool into;
    [SerializeField] Inventary inve;
    [SerializeField] Collider col;


    void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E))
        {
            into= false;
            inve.bKEy = true;
            text.SetActive(false);
            col.enabled= false;
            Destroy(containerKey);
            StartCoroutine("Dialogue");
        }
    }

    public IEnumerator Dialogue()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Charlie...";
        yield return new WaitForSeconds(2);
        dialogue.SetActive(false);
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
