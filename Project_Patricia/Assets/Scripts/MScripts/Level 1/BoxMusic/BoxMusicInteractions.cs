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
    [SerializeField] private GameObject prota, cam, panel;

    [SerializeField] private GameObject lanter;
    [SerializeField] private Animator animDoor;
    [SerializeField] private GameObject pass;
    public bool bAlarm;

    public enum Work
    {
        tras, shopping, firewood, boxMusic
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
                }
            }
        }
    }

    public void LessMusic()
    {
        if (inve.pillsTakes == 3)
        {
            inve.boxMusic.volume -= 0.003f;
            if (inve.boxMusic.volume == 0)
            {
                inve.boxMusic.Pause();

                if (alarmCount < 3)
                alarmCount++;

                if(alarmCount == 1)
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
    }
}
