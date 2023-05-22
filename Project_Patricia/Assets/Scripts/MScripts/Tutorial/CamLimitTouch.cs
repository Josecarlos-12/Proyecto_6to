using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CamLimitTouch : MonoBehaviour
{
    [SerializeField] private GameObject container;    
    [SerializeField] private GameObject prota, cam;    
    [SerializeField] private GameObject rotation;
    [SerializeField] private GameObject dialogue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cam.transform.rotation = this.transform.rotation;
            cam.transform.position = prota.transform.position;
            //cam.transform.rotation = rotation.transform.rotation;
            container.SetActive(true);
            prota.SetActive(false);
            StartCoroutine("DialogueTrue");
        }   
    }

    public IEnumerator DialogueTrue()
    {
        yield return new WaitForSeconds(0.3f);
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: No puedo irme muy lejos, tengo cosas por hacer";
        yield return new WaitForSeconds(3);
        dialogue.SetActive(false);
    }
}
