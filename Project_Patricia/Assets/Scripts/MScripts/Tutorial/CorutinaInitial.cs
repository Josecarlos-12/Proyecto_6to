using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CorutinaInitial : MonoBehaviour
{

    [SerializeField] private float[] time;
    [SerializeField] private string[] text;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private GameObject textContainer;
    [SerializeField] private GameObject cam, prota;


    IEnumerator Start()
    {
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
        prota.SetActive(true);
        textContainer.SetActive(false);
        Destroy(cam);        
    }
}
