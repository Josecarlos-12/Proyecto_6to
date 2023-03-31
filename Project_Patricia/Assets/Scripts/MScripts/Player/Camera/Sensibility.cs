using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensibility : MonoBehaviour
{    

    public Slider sensibility;
    public float sliderValue;

    public void Start()
    {
        Cursor.visible = false;
        sensibility.value = PlayerPrefs.GetFloat("SenMouse", sliderValue);
    }


    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("SenMouse", sliderValue);
    }
}
