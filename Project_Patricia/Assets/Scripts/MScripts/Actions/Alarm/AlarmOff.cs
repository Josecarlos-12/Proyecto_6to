using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AlarmOff : MonoBehaviour
{
    [SerializeField] private AudioSource alarm;
    [SerializeField] private bool into;
    [SerializeField] private BoxMusicInteractions box;
    [SerializeField] private GameObject text;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject textMesh;
    [SerializeField] private GameObject[] coliders;



    void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E) && box.bAlarm==true)
        {
            into = false;
            col.enabled = false;
            alarm.Pause();
            alarm.enabled = false;
            col.enabled= false;
            text.SetActive(false);

            StartCoroutine("Dialogue");

            for (int i = 0; i < coliders.Length; i++)
            {
                coliders[i].SetActive(true);
            }
        }
    }

    public IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(5);
        textMesh.SetActive(true);
        textMesh.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¿Papá?";
        yield return new WaitForSeconds(2);
        textMesh.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Papá!";
        yield return new WaitForSeconds(2);
        textMesh.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Charlie?";
        yield return new WaitForSeconds(2);
        textMesh.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: !Papá!, no creerás lo que encontré, ¡Ven, sígueme!";
        yield return new WaitForSeconds(2);
        textMesh.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (box.bAlarm == true)
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
