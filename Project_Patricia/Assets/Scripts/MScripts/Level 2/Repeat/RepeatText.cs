using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RepeatText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [TextArea(4,4)] public string sText;
    [SerializeField] private int count;

    private void OnDisable()
    {
        count = 0;   
    }

    private void Update()
    { 
        if(count<3)
        count++;

        if (count == 1)
        {
            StartCoroutine("Repeat");
        }
    }

    private IEnumerator Repeat()
    {
        yield return new WaitForSeconds(6);
        text.text = sText;
        yield return new WaitForSeconds(3);
        text.text = string.Empty;
        yield return new WaitForSeconds(12);
        yield return Repeat();
    }
 }
