using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cushions : MonoBehaviour
{
    [SerializeField] private bool into;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject cam, prota, text, panel;
    [SerializeField] private NotesUI note;

    private void Update()
    {
        Down();
    }

    public void Down()
    {
        if(into && Input.GetKeyDown(KeyCode.E))
        {
            if (note.check == 4)
            {
                col.enabled = false;
                text.SetActive(false);
                prota.SetActive(false);
                cam.SetActive(true);
                StartCoroutine(Next());
            }
           
        }
    }

    public IEnumerator Next()
    {
        yield return new WaitForSeconds(0.5f);
        panel.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (note.check == 4)
            {
                into = true;
                text.SetActive(true);
            }
               
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = false;
            text.SetActive(false);
        }
    }
}
