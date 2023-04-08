using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueNote : MonoBehaviour
{ 
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private GameObject textContainer;
    [SerializeField] private bool into;
    [SerializeField] private string text;

    private void Update()
    {
        if ( into)
        {
            StartCoroutine("NextDia");
        }
    }

    public void Dialogue()
    {
        into = true;
    }

    public IEnumerator NextDia()
    {
        textContainer.SetActive(true);
        textMeshPro.text = text;
        yield return new WaitForSecondsRealtime(2);
        into = false;
        textContainer.SetActive(false);
    }
}
