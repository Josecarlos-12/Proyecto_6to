using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPills : MonoBehaviour
{
    [SerializeField]private GameObject[] pills;
    [SerializeField] private GameObject panel;
    [SerializeField] private int one;

    private void Update()
    {
        if (pills[0] == null || pills[1] == null || pills[2] == null)
        {
            if(one<3)
            {
                one++;
            }

            if (one == 1)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                panel.SetActive(true);
            }
        }
    }


    public void ButtonAccept()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        panel.SetActive(false);
    }
}
