using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxMusicInteractions : MonoBehaviour
{

    public bool open;
    [SerializeField] Animator anim;
    [SerializeField] PickableObject pick, pick2;
    [SerializeField] TrashOn trashOne;
    public NotesUI note;
    [SerializeField] private int count;
    [SerializeField] private AudioSource audi;
    [SerializeField] private int cDream;
    [SerializeField] private SleepMode sleep;
    [SerializeField] private Inventary inve;
    [SerializeField] private GameObject pills;

    [SerializeField] private AudioSource alarm;
    [SerializeField] private int alarmCount;
    [SerializeField] private GameObject prota, cam, panel,posEventPills;

    [SerializeField] private GameObject lanter;
    [SerializeField] private Animator animDoor;
    [SerializeField] private GameObject pass;
    public bool bAlarm;

    [SerializeField] private GameObject panelAccept;
    [SerializeField] private int i;
    [SerializeField] private bool accept;

    [Header("Dialogue")]
    [SerializeField] private GameObject text;
    [SerializeField] private AudioSource audioMike;
    [SerializeField] private AudioClip[] clip;

    public enum Work
    {
        tras, shopping, firewood, boxMusic, chart
    }
    public Work word;

    private void Start()
    {
        open = true;
    }

    void Update()
    {
        LessMusic();


        if (trashOne.into)
        {
            if (count < 3)
                count++;

            if (count == 1)
            {
                switch (word)
                {
                    case Work.tras:
                        note.check = 1;
                        anim.SetBool("Open", true);
                        break;
                    case Work.shopping:
                        note.check = 2;
                        break;
                    case Work.firewood:
                        note.check = 8;
                        break;
                        case Work.boxMusic:
                        audi.Play();
                        Dream();
                        break;
                    case Work.chart:
                        break;
                }
            }
        }
    }

    public void LessMusic()
    {
        if (inve.pillsTakes == 3 && inve.complete)
        {
            inve.boxMusic.volume -= 0.003f;
            if (inve.boxMusic.volume == 0)
            {
                inve.boxMusic.Pause();

                if (alarmCount < 3)
                    alarmCount++;

                if (alarmCount == 1)
                {
                    bAlarm = true;
                    alarm.Play();
                    lanter.SetActive(true);
                    pass.SetActive(false);
                    animDoor.SetBool("Close", false);

                    StartCoroutine("NoSleep");

                    sleep.motionBlur.active = false;
                    sleep.cAberration.active = false;
                    sleep.run.canRun = true;
                    sleep.crouch.crouchCan = true;
                }
            }
        }
    }  

    public IEnumerator NoSleep()
    {
        yield return new WaitForSeconds(2);
        prota.transform.position = posEventPills.transform.position;
        prota.transform.rotation = posEventPills.transform.rotation;
        prota.SetActive(true);
        cam.SetActive(false);
        panel.SetActive(false);
    }

    public void Dream()
    {
        if(cDream<3)
        cDream++;

        if (cDream == 1)
        {
            StartCoroutine("IEDream");
        }
    }

    public IEnumerator IEDream()
    {
        yield return new WaitForSeconds(3);
        sleep.ModeDreams();
        pills.SetActive(true);
        //Texto cuando suena la caja y empieza el modo sueño.
        yield return new WaitForSeconds(1);
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Ohh... Mi cabeza me explota...";
        audioMike.clip = clip[0];
        audioMike.Play();
        yield return new WaitForSeconds(3);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: necesito mis pastillas...";
        yield return new WaitForSeconds(3);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Están en mi habitación";
        yield return new WaitForSeconds(2);
        text.SetActive(false);
    }
}
