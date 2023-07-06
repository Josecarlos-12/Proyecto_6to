using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialoguesLevel2Final : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;
    [SerializeField] private GameObject chapter;    
    [SerializeField] private AudioSource audioChapter;
    [SerializeField] private AudioSource audioMike;
    [SerializeField] private AudioClip clip;

    public IEnumerator Dialogues()
    {
        audioMike.clip= clip;
        audioMike.Play();
        yield return new WaitForSeconds(2);        
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Papá, ayudaaaa!";
        yield return new WaitForSeconds(2);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Papá por favooor!";
        yield return new WaitForSeconds(3);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Charlie!";
        yield return new WaitForSeconds(2);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: ¡Miiiiikee!";
        yield return new WaitForSeconds(2);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: ¡Mikee, ayúdame!";
        yield return new WaitForSeconds(3);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Cat!";
        yield return new WaitForSeconds(2);
        dialogue.SetActive(false);
        yield return new WaitForSeconds(3);
        dialogue.SetActive(false);
        dialogue.GetComponent<TextMeshProUGUI>().text = "(Voces)";
        //dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Te necesitooooo!";
        yield return new WaitForSeconds(2);
        //dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Ya voy hijo!";
        yield return new WaitForSeconds(3);
        dialogue.SetActive(false);
        //dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: ¡Miiiikeee!";
        yield return new WaitForSeconds(2);
        //dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Papaaaa!";
        yield return new WaitForSeconds(2);
        //dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: ¡Miiiikeee!";
        yield return new WaitForSeconds(2);
        //dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Papaaaa!";
        yield return new WaitForSeconds(2);
        
        yield return new WaitForSeconds(2);
        audioChapter.Play();
        chapter.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Nivel 3");
    }

}
