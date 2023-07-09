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
    [SerializeField] private Collider colNote;
    [SerializeField] private AudioSource audioDoor, door2;

    [SerializeField] private GameObject repeat;
    [SerializeField] private RepeatText repeatText;
    [SerializeField] private AudioClip clipRepeat;

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
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Qué, qué fue eso? Ooohhmm mi cabeza...¿A qué hora me dormí? Ohh, es tardísimoTengo que colocar la alarma.";
        audioMike.clip = clip[0];
        audioMike.Play();
        yield return new WaitForSeconds(2f);
        audioDoor.enabled= true;
        door2.enabled= true;
        yield return new WaitForSeconds(11f);
        repeat.SetActive(true);
        repeatText.sText = "Mike Schmith: Me pareció haber visto algo cerca de la entrada";
        repeatText.clip= clipRepeat;
        colNote.enabled= true;
        text.SetActive(false);
        note.SetBool("On", true);
    }
}
