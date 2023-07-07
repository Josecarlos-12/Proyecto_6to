using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class CorutinaInitial : MonoBehaviour
{
    [SerializeField] private AudioSource phone;
    [SerializeField] private float[] time;
    [SerializeField, TextArea(4,4)] private string[] text;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private GameObject textContainer, panelTuto;
    [SerializeField] private GameObject cam, prota;
    [SerializeField] private bool press;
    [SerializeField] private TasksUI task;

    [SerializeField] private AudioSource audioMike;
    [SerializeField] private AudioSource audioCatelyn;
    [SerializeField] private AudioClip[] clip;

    [SerializeField, Header("Call Other Scritp")] private SleepMode sleep;

    [Header("Volume")]
    public Volume volume;
    public Bloom bloom;
    public MotionBlur motionBlur;
    public ChromaticAberration cAberration;

    public IEnumerator Start()
    {
        volume.profile.TryGet(out MotionBlur mBlur);
        motionBlur = mBlur;

        volume.profile.TryGet(out ChromaticAberration cromatic);
        cAberration = cromatic;

        volume.profile.TryGet(out Bloom bLoom);
        bloom = bLoom;

        motionBlur.active = true;
        cAberration.active = true;
        bloom.active = true;
        bloom.intensity.value= 0.4f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        yield return new WaitForSeconds(3.5f);
        phone.Stop();

        yield return new WaitForSeconds(time[0]);
        textContainer.SetActive(true);
        audioCatelyn.clip = clip[0];
        audioCatelyn.Play();
        textMeshPro.text = text[0];
        yield return new WaitForSeconds(time[1]);
        textMeshPro.text = text[1];
        yield return new WaitForSeconds(time[2]);
        textMeshPro.text = text[2];
        yield return new WaitForSeconds(time[3]);
        textMeshPro.text = text[3];
        yield return new WaitForSeconds(time[4]);
        audioMike.clip = clip[1];
        audioMike.Play();

        bloom.intensity.value = 0f;
        motionBlur.active = false;
        cAberration.active = false;
        bloom.active = false;

        textMeshPro.text = text[4];
        yield return new WaitForSeconds(time[5]);
        textMeshPro.text = "Catelyn Schmith: ¿Podrías contestar el teléfono por favor?";
        yield return new WaitForSeconds(4);
        audioMike.clip = clip[7];
        audioMike.Play();
        textMeshPro.text = text[10];
        yield return new WaitForSeconds(4);
        panelTuto.SetActive(true);
        phone.Play();
        phone.volume = 1f;
        prota.SetActive(true);
        textContainer.SetActive(false);
        press = true; 
        Destroy(cam);
        /*audioCatelyn.clip = clip[2];
        //audioCatelyn.Play();
        //textMeshPro.text = text[5];
        yield return new WaitForSeconds(time[6]);
        audioMike.clip = clip[1];
        audioMike.Play();
        textMeshPro.text = text[6];
        yield return new WaitForSeconds(time[7]);
        audioCatelyn.clip = clip[4];
        audioCatelyn.Play();
        textMeshPro.text = text[7];
        yield return new WaitForSeconds(time[8]);
        audioMike.clip = clip[5];
        audioMike.Play();
        textMeshPro.text = text[8];
        yield return new WaitForSeconds(time[9]);
        audioCatelyn.clip = clip[6];
        audioCatelyn.Play();
        textMeshPro.text = text[9];
        yield return new WaitForSeconds(time[10]);
        audioMike.clip = clip[7];
        audioMike.Play();
        textMeshPro.text = text[10];
        yield return new WaitForSeconds(time[11]);
        audioCatelyn.clip = clip[8];
        audioCatelyn.Play();
        textMeshPro.text = text[11];
        yield return new WaitForSeconds(time[12]);
        audioMike.clip = clip[9];
        audioMike.Play();
        textMeshPro.text = text[12];
        yield return new WaitForSeconds(time[13]);
        audioMike.clip = clip[10];
        audioMike.Play();
        textMeshPro.text = text[13];
        yield return new WaitForSeconds(time[14]);
        panelTuto.SetActive(true);
        //Time.timeScale = 0;
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
        Destroy(cam);
        prota.SetActive(true);

        textContainer.SetActive(false);
        press = true;
        task.go = true;*/
    }

    private void Update()
    {
        Omi();
    }

    public void Omi()
    {
        if (Input.GetKeyDown(KeyCode.F12) && !press) 
        {
            //task.go = true;
            audioMike.Stop();
            audioCatelyn.Stop();
            StopCoroutine("Start");
            bloom.intensity.value = 0f;
            motionBlur.active = false;
            cAberration.active = false;
            bloom.active = false;
            press = true;
            panelTuto.SetActive(true);
            //Time.timeScale = 0;
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
            Destroy(cam);
            prota.SetActive(true);
            textContainer.SetActive(false);
        }
    }

    public void ButtonPlay()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Destroy(cam);
        prota.SetActive(true);
        panelTuto.SetActive(false);
        task.go = true;
    }
}
