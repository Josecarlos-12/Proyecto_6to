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
    }

    

    public void Accetp()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            thisColl.enabled = false;
            textE.SetActive(false);
            panel.SetActive(true);
            StartCoroutine("FalsePanel");
            //into = true;
            //textE.SetActive(true);
        }
    }
    public IEnumerator FalsePanel()
    {
        otherColl.enabled = true;
        yield return new WaitForSeconds(10);
        animPanel.SetBool("Off", true);
        yield return new WaitForSeconds(2);
        panel.SetActive(false);
       // Destroy(transform.parent.gameObject);
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
