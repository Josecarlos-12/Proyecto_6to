using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimFlower : MonoBehaviour
{
    [SerializeField] private Animator animCam;
    [SerializeField] private GameObject cam, prota;
    [SerializeField] private Collider col;
    [SerializeField] private Animator animDoor, animDoorV2;
    [SerializeField] private WakingUpMode wakingUp;
    [SerializeField] private GameObject switchGog, switchBad;
    [SerializeField] private GameObject[] lightDesactive;
    [SerializeField] private GameObject openDoor;
    [Header("Task")]
    [SerializeField] private TasksUILevel2 task;
    [SerializeField] private GameObject taskGame;

    [Header("Dialogue")]
    [SerializeField] private GameObject text;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cam.SetActive(true);
            prota.SetActive(false);
            col.enabled = false;
            animCam.enabled = true;
        }
    }

    public IEnumerator Smell()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Aahh, me recuerdan a ella";
        yield return new WaitForSeconds(2);
        text.SetActive(false);
    }

    public void Dream()
    {
        animDoor.SetBool("Close", true);
        animDoorV2.SetBool("Close", true);
        StartCoroutine("ChangeMode");
        switchGog.SetActive(false);
        switchBad.SetActive(true);
        openDoor.SetActive(true);

        for (int i = 0; i < lightDesactive.Length; i++)
        {
            lightDesactive[i].SetActive(false);
        }
    }

    public IEnumerator ChangeMode()
    {
        wakingUp.WakingOn();
        yield return new WaitForSeconds(0.5f);
        wakingUp.WakingOff();
        yield return new WaitForSeconds(0.5f);
        wakingUp.WakingOn();
        yield return new WaitForSeconds(0.5f);
        wakingUp.WakingOff();
        yield return new WaitForSeconds(0.5f);
        wakingUp.WakingOn();
        yield return new WaitForSeconds(1f);
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡¿Caaat?!";
        yield return new WaitForSeconds(1f);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Agh, no creo que me escuche";
        task.taskCount = 1;
        taskGame.SetActive(true);
        task.countT = 0;
        task.go = true;
        task.task = "Returns home";
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
    }

    public void Finish()
    {
        cam.SetActive(false);
        prota.SetActive(true);
    }

}
