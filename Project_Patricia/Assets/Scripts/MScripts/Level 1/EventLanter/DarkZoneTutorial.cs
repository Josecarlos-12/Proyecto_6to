using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkZoneTutorial : MonoBehaviour
{
    [SerializeField] Collider thisColl, otherColl;
    [SerializeField] GameObject panel, textE;
    [SerializeField] bool into;

    [SerializeField] private Animator animPanel;

    void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E))
        {
            
            //Time.timeScale = 0;
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
        }
    }

    public IEnumerator FalsePanel()
    {
        otherColl.enabled = true;
        yield return new WaitForSeconds(10);
        animPanel.SetBool("Off", true);
        yield return new WaitForSeconds(2);
        panel.SetActive(false);
    }

    public void Accetp()
    {
        panel.SetActive(false);
        //Time.timeScale = 1;
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        otherColl.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            thisColl.enabled = false;
            textE.SetActive(false);
            into = false;
            panel.SetActive(true);
            StartCoroutine("FalsePanel");
            //into = true;
            //textE.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //into = false;
            //textE.SetActive(false);
        }
    }
}
