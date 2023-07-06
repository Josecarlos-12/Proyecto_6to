using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabLanterCat : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject lanter, lanterPlayer;
    [SerializeField] private Animator animLanter;
    [SerializeField] private bool into;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject cat;
    [SerializeField] private GameObject panel;
    [SerializeField] private MeshRenderer mesh;
    [SerializeField] private Animator animPanel;

    void Update()
    {
        InputLanter();
    }

    public void InputLanter()
    {
        if (into && Input.GetKeyDown(KeyCode.E))
        {
            animLanter.enabled = true;
            lanterPlayer.SetActive(true);
            text.SetActive(false);
            into = false;
            col.enabled= false;
            cat.SetActive(true);
            mesh.enabled= false;
            lanter.SetActive(false);
            StartCoroutine("Panel");
        }
    }

    public IEnumerator Panel()
    {
        yield return new WaitForSeconds(5);
        panel.SetActive(true);
        yield return new WaitForSeconds(15);
        animPanel.SetBool("Off", true);
        yield return new WaitForSeconds(5);
        panel.SetActive(false);
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
