using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueDorr : MonoBehaviour
{
    [Header("Dialgoue")]
    [SerializeField] private GameObject dialogue;

    [Header("Call Other Script")]
    [SerializeField] private GrabRifleColl fin;
    public Rifle rifle;

    public IEnumerator Dialogue()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Ne- necesito aire";
        yield return new WaitForSeconds(2);
        dialogue.SetActive(false);
        dialogue.GetComponent<TextMeshProUGUI>().text = string.Empty;
    }


    public IEnumerator Crouch()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Que hac�a eso ah�...";
        yield return new WaitForSeconds(2);
        dialogue.SetActive(false);
        dialogue.GetComponent<TextMeshProUGUI>().text = string.Empty;
    }

    public IEnumerator HeadUp()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Qui�n? Qui�n est� ah�?";
        yield return new WaitForSeconds(2);
        dialogue.SetActive(false);
        dialogue.GetComponent<TextMeshProUGUI>().text = string.Empty;
    }


    public void Finish()
    {
        fin.prota.SetActive(true);
        fin.cam.SetActive(false);
    }

    public void DialogueTrue()
    {
        rifle.star = true;
    }
}
