using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishAnimLevel3 : MonoBehaviour
{
    [SerializeField] private GameObject mike;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private GameObject eyes;
    [SerializeField] private GameObject anim;
    [SerializeField] private GameObject animBack;

    public void ActiveAnim()
    {
        anim.SetActive(true);
        animBack.SetActive(false);
    }

    public void OffMike()
    {
        mike.SetActive(false);
    }

    public IEnumerator Dialogue()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: Tranquilo papá, estaremos bien";
        yield return new WaitForSeconds(3);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: Ya no es necesario que te preocupes más por nosotros";
        yield return new WaitForSeconds(3);
        dialogue.SetActive(false);
    }

    public IEnumerator MikeFinish()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Lo sé";
        yield return new WaitForSeconds(2);
        dialogue.SetActive(false);
    }


    public void Eyes()
    {
        eyes.SetActive(true);
    }
}
