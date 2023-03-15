using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DestroyCapsula : MonoBehaviour
{
    [Header("Destroy Cap")]
    [SerializeField] private Light lightLantern;
    [SerializeField] private GameObject cap;
    [SerializeField] private ChartAnim activeCa;

    [Header("Call other Script")]
    [SerializeField] private Weapon weapon;
    [SerializeField] private PlayerInteraction inter;

    [Header("Dialogue")]
    [SerializeField] private GameObject Dialogue;
    [SerializeField] private GameObject triggert;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float[] time;
    [SerializeField, TextArea(4,4)] private string[] nexText;
    [SerializeField] private int CountDialogue;


    void Update()
    {
        DestroyCap();
        ActiveDialogue();
    }

    public void DestroyCap()
    {
        if (activeCa.activeCap && lightLantern.enabled == true)
        {
            EventDestroy();
        }

        if(weapon.save && inter.bCapsule)
        {
            EventDestroy();
        }
    }

    public void EventDestroy()
    {
        Destroy(cap);
    }

    public void ActiveDialogue()
    {
        if (cap == null)
        {
            if(CountDialogue<3)
            CountDialogue++;

            if (CountDialogue == 1)
            {
                StartCoroutine(NexText());
            }            
        }
    }

    public IEnumerator NexText()
    {
        yield return new WaitForSeconds(time[0]);
        Dialogue.SetActive(true);
        text.text = nexText[0];
        yield return new WaitForSeconds(time[1]);
        text.text = nexText[1];
        yield return new WaitForSeconds(time[2]);
        text.text = nexText[2];
        yield return new WaitForSeconds(time[3]);
        text.text = nexText[3];
        yield return new WaitForSeconds(time[4]);
        text.text = nexText[4];
        yield return new WaitForSeconds(time[5]);
        text.text = nexText[5];
        yield return new WaitForSeconds(time[6]);
        text.text = nexText[6];
        yield return new WaitForSeconds(time[7]);
        Dialogue.SetActive(false);
        triggert.SetActive(true);
    }
}
