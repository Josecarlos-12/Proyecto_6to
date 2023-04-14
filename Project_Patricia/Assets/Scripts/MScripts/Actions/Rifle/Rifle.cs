using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [SerializeField] private bool into;
    public bool canRifle;
    [SerializeField] private GameObject text;
    [SerializeField] private Collider col;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Inventary inve;

    [Header("Dialogue")]
    [SerializeField] private GameObject dialogue;
    [SerializeField] private EnemyShed run;
    public bool star;
    public int count;

    private void Update()
    {
       if(star)
        {            
            if (count < 3)
            {
                count++;
            }

            if (count == 1)
            {
                StartCoroutine("DialogueFinal");
            }
        }
    }

    public IEnumerator DialogueFinal()
    {
        yield return new WaitForSeconds(0.6f);
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Hey! ¿Quién eres tú? ¡¿Qué haces en mi propiedad?!";
        yield return new WaitForSeconds(3f);
        dialogue.SetActive(false);
        run.run = true;        
        yield return new WaitForSeconds(1f);
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Hey hablo enserio, vuelve aquí!";
        yield return new WaitForSeconds(2f);
        dialogue.SetActive(false);
        yield return new WaitForSeconds(4f);
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Se está moviendo por entre los arbustos...";
        yield return new WaitForSeconds(2f);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Esta es mi oportunidad, tengo que evitar que me escuche";
        yield return new WaitForSeconds(4f);
        dialogue.SetActive(false);
        this.gameObject.GetComponent<Rifle>().enabled = false;
    }

    public void InpuRifle()
    {
        if (into && Input.GetKeyDown(KeyCode.E))
        {
            inve.rifle= true;
            col.enabled= false;
            text.SetActive(false);
            canRifle = true;
            weapon.shootTwo= true;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(true);
            into = true;                  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(false);
            into = true;
        }
    }
}
