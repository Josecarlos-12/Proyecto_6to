using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensibility : MonoBehaviour
{    

    public Slider sensibility;
    public float sliderValue;
    public enum ValueStart
    {
        none, value
    }
    public ValueStart value;

    public void Start()
    {
        switch (value)
        {
            case ValueStart.none:
                break; 
            case ValueStart.value:
                sliderValue = 3;
                break;
        }

        Cursor.visible = false;
        sensibility.value = PlayerPrefs.GetFloat("SenMouse", sliderValue);
    }


    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("SenMouse", sliderValue);
    }
}
