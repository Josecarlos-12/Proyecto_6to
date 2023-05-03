using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartLevel2 : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private PlayerFPSt walk;
    [SerializeField] private PlayerCrouch crouch;
    [SerializeField] private GameObject eventFindCharlie;

    [Header("Call Other Scripts")]
    [SerializeField] private TasksUILevel2 task;

    public IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Hola? ¿Hola?";
        yield return new WaitForSeconds(4);
        text.SetActive(false);
        walk.canWalk= true;
        crouch.crouchCan= true;
        yield return new WaitForSeconds(1);
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Eso fue muy extraño";
        yield return new WaitForSeconds(3);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Aghh... mi cabeza";
        yield return new WaitForSeconds(3);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Oh, no debo olvidarme de ir a ver a Charlie";
        yield return new WaitForSeconds(5);
        text.SetActive(false);
        task.go = true;
        eventFindCharlie.SetActive(true);
        this.gameObject.GetComponent<StartLevel2>().enabled = false;
    }
}
