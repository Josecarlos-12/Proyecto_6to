using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatCallMike : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;
    [SerializeField] private Collider thisCol;
    [SerializeField] private GameObject mikeCatRoom;

    [Header("Hectic")]
    [SerializeField] private AudioSource hectic;
    [SerializeField] private GameObject prota, point, eyes;
    public enum Touch
    {
        charlie, mikeCatRoom, PentHouse
    }
    public Touch touch;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (touch)
            {
                case Touch.charlie:
                    thisCol.enabled = false;
                    StartCoroutine("Dialogue");
                    break; 
                case Touch.mikeCatRoom:
                    thisCol.enabled = false;
                    StartCoroutine("MikePentHouse");
                    break;
                case Touch.PentHouse:
                    thisCol.enabled = false;
                    StartCoroutine("PentHouse");
                    break;
            }
        }
    }

    public IEnumerator Dialogue()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: ¡Miiiiiike!";
        yield return new WaitForSeconds(2);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: ¡Te necesitooooo!";
        yield return new WaitForSeconds(3);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Caaaat!";
        yield return new WaitForSeconds(2);
        mikeCatRoom.SetActive(true);
        dialogue.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public IEnumerator MikePentHouse()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Papiiiiiii!";
        yield return new WaitForSeconds(2);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Por favor ayudaaaa!";
        yield return new WaitForSeconds(3);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Charlie!";
        mikeCatRoom.SetActive(true);
        dialogue.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public IEnumerator PentHouse()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn: ¡Miiiiiike! \n Charlie: ¡Papaaaaaaa! ";
        yield return new WaitForSeconds(4);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn: ¡Miiiiiike! \n Charlie: ¡Papiiii! por favooor";
        //agitado
        hectic.Play();
        yield return new WaitForSeconds(4);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn: ¡Miiiiiiiiikee! ¡Ayudaaa! \n Charlie: ¡Papaaaaaaa! ";
        //agitado
        hectic.Play();
        yield return new WaitForSeconds(4);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn: ¡Miiiiiiiiikee, te lo suplicoo!";
        hectic.Play();
        yield return new WaitForSeconds(3);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡AAAAAAAHHHHHHH!";
        //Cierra Ojos
        eyes.SetActive(true);
        yield return new WaitForSeconds(3);
        prota.transform.position = point.transform.position;
        prota.transform.rotation = point.transform.rotation;
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn: ¡Miiiiiike! \n Charlie: ¡Papaaaaaaa! ";
        hectic.Play();
        yield return new WaitForSeconds(2);
        // Abre los Ojos
        yield return new WaitForSeconds(2);
        dialogue.GetComponent<TextMeshProUGUI>().text = "¿Escuchas sus voces?";
        yield return new WaitForSeconds(2);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Igual yo...";
        yield return new WaitForSeconds(2);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Todo el tiempo...";
    }
}
