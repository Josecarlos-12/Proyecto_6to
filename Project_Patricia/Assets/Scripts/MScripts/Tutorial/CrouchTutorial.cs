using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrouchTutorial : MonoBehaviour
{
    [SerializeField] PlayerCrouch crouch;
    [SerializeField] GameObject text;
    [SerializeField] int count;
    public bool active;
    [SerializeField] private AudioSource audioMike;
    [SerializeField] private AudioClip silenceClip, slowlyClip;
    [SerializeField] private GameObject limit;


    void Update()
    {
        if (crouch.crouch && active)
        {

            if(count<3)
            count++;


            if (count == 1)
            {
                StartCoroutine("Dialogue");
            }

            
        }
    }



    public IEnumerator Dialogue()
    {
        audioMike.clip = silenceClip;
        audioMike.Play();
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Shh... Silencio... Despacio..";
        yield return new WaitForSeconds(1f);
        audioMike.clip = slowlyClip;
        audioMike.Play();
        yield return new WaitForSeconds(1f);
        limit.SetActive(true);
        text.SetActive(false);
    }
}
