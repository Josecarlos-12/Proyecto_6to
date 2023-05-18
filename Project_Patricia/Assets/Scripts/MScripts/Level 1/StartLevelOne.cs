using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartLevelOne : MonoBehaviour
{
    [SerializeField] private GameObject cam, prota, panel;
    [SerializeField] private GameObject text;
    [SerializeField] private PanelInitial init;
    [SerializeField] private int count;

    [SerializeField] private AudioSource audioMike;
    [SerializeField] private AudioClip[] clip;

    [SerializeField] private Animator note;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(4.10f);
        cam.SetActive(false);
        prota.SetActive(true);
        yield return new WaitForSeconds(10f);
        Destroy(panel);
    }

    private void Update()
    {
        if (init.dialogue)
        {
            if(count<3)
            count++;

            if (count == 1)
            {
                StartCoroutine("Eyes");
                init.dialogue = false;
            }
        }
    }

    public IEnumerator Eyes()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: �Qu�, qu� fue eso? Ooohhmm mi cabeza...�A qu� hora me dorm�? Ohh, es tard�simoTengo que colocar la alarma.";
        audioMike.clip = clip[0];
        audioMike.Play();
        yield return new WaitForSeconds(13f);
        text.SetActive(false);
        note.SetBool("On", true);
    }
}
