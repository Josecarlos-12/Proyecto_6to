using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillStopRepeat : MonoBehaviour
{
    [SerializeField] private GameObject repeat;
    [SerializeField] private RepeatText repeatText;
    [SerializeField] private int repeatCount;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            repeatText.texContainer.SetActive(false);
            repeatText.audio.Stop();
            repeat.SetActive(false);
            repeatText.StopCoroutine("Repeat3");
            Destroy(gameObject);
        }
    }
}
