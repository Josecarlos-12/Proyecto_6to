using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueNote : MonoBehaviour
{ 
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private GameObject textContainer;

    public IEnumerator Dialogue()
    {
        print("Dialogo");
        textContainer.SetActive(true);
        textMeshPro.text = "A ver que tenemos...";
        yield return new WaitForSecondsRealtime(3);
        textContainer.SetActive(false);
    }
}
