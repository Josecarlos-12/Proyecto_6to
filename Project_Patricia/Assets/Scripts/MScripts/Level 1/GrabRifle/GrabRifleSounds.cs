using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrabRifleSounds : MonoBehaviour
{
    public bool grab, into;
    [SerializeField] private GameObject text, pressE, wayPoint, charlie;
    [SerializeField] private Collider col;
    [SerializeField] private AudioSource[] audioRifle;
    [SerializeField] private MeshRenderer mesh;


    [SerializeField] private GameObject shadowBattle;

    [SerializeField, Header("Call Other Script")] private Weapon weapon;
    [SerializeField] private Inventary inve;

    void Update()
    {
        if (grab && into && Input.GetKeyDown(KeyCode.E))
        {
            wayPoint.SetActive(true);
            inve.rifle = true;
            pressE.SetActive(false);
            weapon.shootTwo = true;

            mesh.enabled= false;
            into = false;
            col.enabled = false;
            StartCoroutine("Dialogue");
            Destroy(charlie);
            for (int i = 0; i < audioRifle.Length; i++)
            {
                Destroy(audioRifle[i]);
            }

        }
    }

    public IEnumerator Dialogue()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Te encontraré...";
        yield return new WaitForSeconds(2);
        shadowBattle.SetActive(true);
        text.SetActive(false);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (grab)
            {
                pressE.SetActive(true);
                into = true;
            }            
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
                pressE.SetActive(false);
                into = false;
            
        }

    }
}
