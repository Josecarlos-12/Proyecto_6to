using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sensitivity : MonoBehaviour
{
    //public NewCamera Cam;
    public Slider slider;
    public float sliderValue = 2;
    void Start()
    {
        slider.maxValue = 8;
        slider.minValue = 1;
        slider.value = PlayerPrefs.GetFloat("sensibilidad", 2);
        //Cam.mouseSensitivity = sliderValue * 40;
    }
    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.GetFloat("brillo", sliderValue);
        //Cam.mouseSensitivity = sliderValue * 40;
    }

}
