using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChartCatBasement : MonoBehaviour
{
    [SerializeField] private GameObject cam, prota, chart;
    [SerializeField] private GameObject dialogue, shed;
    [SerializeField] private bool init;
    [SerializeField] private Animator animDoor;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text= "Mike Schmith: Cierto, la llave la guardé ahí, en el cobertizo";
        yield return new WaitForSeconds(2f);
        dialogue.SetActive(false);
        init= true;
        animDoor.SetBool("Close", false);
        shed.SetActive(true);
    }
}
