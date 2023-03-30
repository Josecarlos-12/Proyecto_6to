using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabOne : MonoBehaviour
{
    [SerializeField] private TrashOn[] trash;
    [SerializeField] private GameObject grabTuto;
    [SerializeField] private int count;

    void Update()
    {
        if (trash[0].countPlayer == 1 || trash[1].countPlayer == 1 || trash[2].countPlayer == 1 || trash[3].countPlayer == 1 || trash[4].countPlayer == 1 || trash[5].countPlayer == 1)
        {
            if (count < 3)
                count++;
        }

        if(count == 1)
        {
            grabTuto.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void ButtonAccept()
    {
        count = 3;

        grabTuto.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Destroy(gameObject);
    }
}
