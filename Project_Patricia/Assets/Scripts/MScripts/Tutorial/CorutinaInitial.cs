using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CorutinaInitial : MonoBehaviour
{

    [SerializeField] private float[] time;
    [SerializeField, TextArea(4,4)] private string[] text;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private GameObject textContainer, panelTuto;
    [SerializeField] private GameObject cam, prota;
    [SerializeField] private bool press;


    public IEnumerator Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        yield return new WaitForSeconds(time[0]);
        textMeshPro.text = text[0];
        yield return new WaitForSeconds(time[1]);
        textMeshPro.text = text[1];
        yield return new WaitForSeconds(time[2]);
        textMeshPro.text = text[2];
        yield return new WaitForSeconds(time[3]);
        textMeshPro.text = text[3];
        yield return new WaitForSeconds(time[4]);
        textMeshPro.text = text[4];
        yield return new WaitForSeconds(time[5]);
        textMeshPro.text = text[5];
        yield return new WaitForSeconds(time[6]);
        textMeshPro.text = text[6];
        yield return new WaitForSeconds(time[7]);
        textMeshPro.text = text[7];
        yield return new WaitForSeconds(time[8]);
        textMeshPro.text = text[8];
        yield return new WaitForSeconds(time[9]);
        textMeshPro.text = text[9];
        yield return new WaitForSeconds(time[10]);
        textMeshPro.text = text[10];
        yield return new WaitForSeconds(time[11]);
        textMeshPro.text = text[11];
        yield return new WaitForSeconds(time[12]);
        textMeshPro.text = text[12];
        yield return new WaitForSeconds(time[13]);
        textMeshPro.text = text[13];
        yield return new WaitForSeconds(time[14]);
        panelTuto.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        textContainer.SetActive(false);
        press = true;
    }

    private void Update()
    {
        Omi();
    }

    public void Omi()
    {
        if (Input.GetKeyDown(KeyCode.F12) && !press) 
        {
            StopCoroutine("Start");
            press = true;
            panelTuto.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
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
    }
}
