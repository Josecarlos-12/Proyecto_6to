using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class SleepMode : MonoBehaviour
{
    [SerializeField] private int cFour;
    public NotesUI note;

    [Header("Volume")]
    public Volume volume;
    public MotionBlur motionBlur;
    public ChromaticAberration cAberration;
    public PlayerCrouch crouch;
    public PlayerFPSt run;

    [Header("Dialogue")]
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private GameObject textContainer;
    [SerializeField] private AudioSource audioMike;
    [SerializeField] private AudioClip[] clip;


    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGet(out MotionBlur mBlur);
        motionBlur = mBlur;

        volume.profile.TryGet(out ChromaticAberration cromatic);
        cAberration = cromatic;
    }

    // Update is called once per frame
    void Update()
    {
        CheckFour();
    }

    public void CheckFour()
    {
        if (note.one && note.two && note.three && note.four && note.eight && note.nine)
        {
            if (cFour < 3)
                cFour++;

            if (cFour == 1)
            {
                ModeDreams();
                StartCoroutine("NextDia");
            }
        }
    }

    public IEnumerator NextDia()
    {
        textContainer.SetActive(true);
        textMeshPro.text = "Mike Schmith: Oohhmm qué cansado me siento, creo que descanzaré unos minutos.";
        yield return new WaitForSecondsRealtime(6);
        audioMike.clip = clip[0];
        audioMike.Play();
        textContainer.SetActive(false);
    }

    public void ModeDreams()
    {
        motionBlur.active = true;
        cAberration.active = true;
        run.canRun = false;
        crouch.crouchCan = false;
        print("ModoSueño"); 
    }

    public void OffDreams()
    {
        motionBlur.active = false;
        cAberration.active = false;
        run.canRun = true;
        crouch.crouchCan = true;
    }

}
