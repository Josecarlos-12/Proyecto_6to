using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabFlashBack : MonoBehaviour
{
    public bool into, grab;
    [SerializeField] private GameObject textE;
    [SerializeField] private SleepMode sleep;
    [SerializeField] private Collider coll;

    private void Update()
    {
        PressInput();
    }

    public void PressInput()
    {
        if(into && Input.GetKeyUp(KeyCode.E))
        {
            grab = true;
            textE.SetActive(false);
            coll.enabled = false;
            into = false;
            sleep.ModeDreams();
            StartCoroutine("OffDream");
        }
    }

    public IEnumerator OffDream()
    {
        yield return new WaitForSeconds(3);
        sleep.OffDreams();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textE.SetActive(true);
            into= true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textE.SetActive(false);
            into = false;
        }
    }
}
