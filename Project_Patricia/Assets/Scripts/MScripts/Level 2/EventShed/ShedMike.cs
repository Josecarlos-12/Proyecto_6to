using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShedMike : MonoBehaviour
{
    [SerializeField] private GameObject dialogue, mike;
    [SerializeField] private AudioSource audioScare;
    [SerializeField] private Collider col;

    [Header("Batlle")]
    [SerializeField] private GameObject shadowMike;
    [SerializeField] private GameObject stopBattle, stopBattle2;
    [SerializeField] private AudioSource audioBattle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "DeEyes")
        {
            col.enabled= false;
            StartCoroutine("Dialogue");
        }
    }

    public IEnumerator Dialogue()
    {
        audioScare.Play();
        //dialogue.SetActive(true);
        //dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Qué? ¿Tú otra vez?";
        yield return new WaitForSeconds(0.3f);
        mike.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        mike.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        mike.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        //dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡No tengo tiempo para esto!";

        shadowMike.SetActive(true);
        stopBattle.SetActive(true);
        stopBattle2.SetActive(true);
        audioBattle.Play();
        audioBattle.loop = true;
        yield return new WaitForSeconds(3);
        //dialogue.SetActive(false);
    }


}
