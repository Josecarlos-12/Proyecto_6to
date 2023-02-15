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
        prota.SetActive(true);
        textContainer.SetActive(false);
        Destroy(cam);        
    }
}
