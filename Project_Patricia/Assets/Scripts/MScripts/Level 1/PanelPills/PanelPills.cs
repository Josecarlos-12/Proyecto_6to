using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPills : MonoBehaviour
{
    [SerializeField]private GameObject[] pills;
    [SerializeField] private GameObject panel, tutoPills;
    [SerializeField] private int one;
    [SerializeField] AnimTrue animPill;

    private void Update()
    {
        TutoPills();
        InputPills();
    }

    public void TutoPills()
    {
        if (pills[0] == null && pills[1] == null && pills[2] == null)
        {
            if (one < 3)
            {
                one++;
            }

            if (one == 1)
            {
                tutoPills.SetActive(true);
            }
        }
    }

    public void InputPills()
    {
        if(animPill.init && Input.GetKeyDown(KeyCode.Alpha2))
        {
            tutoPills.SetActive(false);
            animPill.init = false;
            panel.SetActive(true);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void ButtonAccept()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        panel.SetActive(false);
        this.gameObject.GetComponent<PanelPills>().enabled = false;
    }
}
