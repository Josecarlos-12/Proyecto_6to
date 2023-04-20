using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueNote : MonoBehaviour
{ 
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private GameObject textContainer;
    [SerializeField] private bool into, grabNote;
    [SerializeField] private string text;
    [SerializeField] private int count;

    [SerializeField] private AudioSource audioMike;
    [SerializeField] private AudioClip[] clip;

    private void Update()
    {
        if ( into)
        {
            if (count < 3)
            {
                count++;
            }

            if (count == 1)
            {
                StartCoroutine("NextDia");
            }
            
        }
    }

    public void Dialogue()
    {
        into = true;
    }

    public IEnumerator NextDia()
    {
        textContainer.SetActive(true);
        textMeshPro.text = text;
        audioMike.clip = clip[0];
        audioMike.Play();
        yield return new WaitForSecondsRealtime(2);       
        grabNote =true;
        into = false;
        textContainer.SetActive(false);
    }
}
