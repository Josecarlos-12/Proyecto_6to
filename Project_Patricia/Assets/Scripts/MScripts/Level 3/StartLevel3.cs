using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartLevel3 : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;
    [SerializeField] private GameObject charliePenthouse, charlieRoom;
    [SerializeField] private GameObject catBasement;
    [SerializeField] private GameObject touchCharlie;

    public IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        //charliePenthouse.GetComponent<AudioSource>().Play();
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Papaaaaaaa! ayudaaaa!";
        yield return new WaitForSeconds(3);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Charlie! Ya voy hijo!";
        yield return new WaitForSeconds(3);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: Papaaaaaaa! Por favooooor!";
        yield return new WaitForSeconds(3);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Charlie!";
        yield return new WaitForSeconds(1);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡La puerta no se abre!";
        yield return new WaitForSeconds(2);
        //En ese momento se va a escuchar la voz de Catelyn llamando a Mike desde el sótano
        //catBasement.GetComponent<AudioSource>().Play();
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: ¡Miiiiiike!";
        yield return new WaitForSeconds(2);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Cat?";
        yield return new WaitForSeconds(2);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: ¡Miiiiiikeeee ayúdameeeee!";
        yield return new WaitForSeconds(3);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Caaaat! ¡Esperame!";
        yield return new WaitForSeconds(2);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: ¡Miiiiiike!";
        yield return new WaitForSeconds(2);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Caaaat!";
        yield return new WaitForSeconds(2);
        // Luego Charlie volverá a llamar a Mike desde la habitación de Charlie
        //charlieRoom.GetComponent<AudioSource>().Play();
        dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Papaaaaaa! ¡Tengo miedooo!";
        yield return new WaitForSeconds(3);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Hijo!";
        yield return new WaitForSeconds(2);
        dialogue.SetActive(false);
        touchCharlie.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
