using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TouchTuto : MonoBehaviour
{
    [SerializeField] Collider col;
    [SerializeField] GameObject gameObj, text;

    private void Start()
    {
        gameObj  = this.gameObject;
        col = GetComponent<Collider>();
        gameObj.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            col.enabled = false;
        }
    }

    public IEnumerator Dialogue()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Maldición ¿Lo perdí?";
        yield return new WaitForSeconds(3);
        text.SetActive(false);
        Destroy(gameObject);
    }
}
