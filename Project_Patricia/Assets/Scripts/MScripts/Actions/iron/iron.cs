using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;
using static UnityEngine.Rendering.DebugUI;
using Unity.VisualScripting;

public class iron : MonoBehaviour
{
    [SerializeField] private bool into;
    [SerializeField] private bool cF;
    [SerializeField] private int count, cFour;
    [SerializeField] private GameObject cam, prota, panel, textE, wornClothes, cleanClothes;
    public NotesUI note;

    [Header("Volume")]
    [SerializeField] private Volume volume;
    [SerializeField] private MotionBlur motionBlur;
    [SerializeField] private ChromaticAberration cAberration;
    public PlayerCrouch crouch;
    public PlayerFPSt run;

    public enum Check
    {
        three, four
    }
    public Check check;

    private void Start()
    {

        switch (check)
        {
            case Check.three:

                break;
            case Check.four:
                volume.profile.TryGet(out MotionBlur mBlur);
                motionBlur = mBlur;

                volume.profile.TryGet(out ChromaticAberration cromatic);
                cAberration = cromatic;
                break;
        }       
    }

    private void Update()
    {
        Iron();
        CheckFour();
    }

    public void Iron()
    {
        if(into  && Input.GetKeyDown(KeyCode.E) && count ==0)
        {
            count++;
            prota.SetActive(false);
            panel.SetActive(true);
            cam.SetActive(true);
            textE.SetActive(false);
            StartCoroutine(Next());
        }
    }

    public IEnumerator Next()
    {
        yield return new WaitForSeconds(1);
        Destroy(wornClothes);
        cleanClothes.SetActive(true);
        yield return new WaitForSeconds(1);
        prota.SetActive(true);
        panel.SetActive(false);
        cam.SetActive(false);
        switch (check)
        {
            case Check.three:
                note.check = 3;
                break;
                case Check.four:
                note.check = 4;
                cF = true;
                break;
        }
    }

    public void CheckFour()
    {
        if(note.check == 4)
        {
            if(cFour<3)
            cFour++;

            if(cFour== 1)
            {
                motionBlur.active = true;
                cAberration.active = true;
                run.canRun= false;
                crouch.crouchCan = false;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = true;
            if (count == 0)
            {
                textE.SetActive(true);
            }            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = false;
            textE.SetActive(false);
        }
    }
}
