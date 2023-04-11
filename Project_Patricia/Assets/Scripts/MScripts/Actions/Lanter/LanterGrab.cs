using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LanterGrab : MonoBehaviour
{
    [SerializeField] private GameObject text, lanter, childMove;
    [SerializeField] private bool into;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject dialogueText;

    private void Update()
    {
        Press();
    }

    public void Press()
    {
        if (into && Input.GetKeyDown(KeyCode.E))
        {
            childMove.SetActive(true);
            lanter.SetActive(true);
            col.enabled = false;
            text.SetActive(false);
            Destroy(transform.GetChild(0).gameObject);
            StartCoroutine("Dialogue");
        }
    }

    public IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(5);
        dialogueText.SetActive(true);
        dialogueText.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Charlie! Regresa! ¡Es peligroso que estes fuera!";
        yield return new WaitForSeconds(4);
        dialogueText.SetActive(false);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(true);
            into= true;
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
