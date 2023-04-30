using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RingPlay : MonoBehaviour
{
    public CountFlash count;
    [SerializeField] private GameObject textE, panel, Level2, cam, prota;
    [SerializeField] private bool into;
    [SerializeField] private Collider col;

    // Update is called once per frame
    void Update()
    {
        if (count.ring && into && Input.GetKeyDown(KeyCode.E))
        {
            col.enabled= false;
            into = false;
            textE.SetActive(false);
            panel.SetActive(true);
            Level2.SetActive(true);
            cam.SetActive(true);
            prota.SetActive(false);
            StartCoroutine("NextLevel");
        }
    }

    public IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Nivel 2");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (count.ring)
            {
                into = true;
                textE.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (count.ring)
            {
                into = false;
                textE.SetActive(false);
            }
        }
    }
}
