using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartLevel2 : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private PlayerFPSt walk;
    [SerializeField] private PlayerCrouch crouch;


    public IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¿Hola? ¿Hola?";
        yield return new WaitForSeconds(4);
        text.SetActive(false);
        walk.canWalk= true;
        crouch.crouchCan= true;
        this.gameObject.GetComponent<StartLevel2>().enabled = false;
    }
}
