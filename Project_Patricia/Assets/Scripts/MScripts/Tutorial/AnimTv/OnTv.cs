using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTv : MonoBehaviour
{
    [SerializeField] private GameObject eText, cam, prota, ui, lightSpot;
    [SerializeField] private bool into, into2;
    [SerializeField] private Animator anim;
    [SerializeField] private Animator animSpot;
    [SerializeField] private MeshRenderer wall;
    [SerializeField] private Material wallBad;
    [SerializeField] private Material wallGod;
    [SerializeField] private WakingUpMode waking;

    private void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E))
        {
            ui.SetActive(false);
            anim.enabled= true;
            eText.SetActive(false);
            into = false;
            prota.SetActive(false);
            cam.SetActive(true);
            StartCoroutine("PressE");
        }

        if (into2 && Input.GetKeyDown(KeyCode.E))
        {
            enabled= false;
            ui.SetActive(true);
            prota.SetActive(true);
            cam.SetActive(false);
        }
    }

    public IEnumerator PressE()
    {
        yield return new WaitForSeconds(1);
        into2 = true;
        yield return new WaitForSeconds(5);
        lightSpot.SetActive(false);
        animSpot.enabled= true;
        yield return new WaitForSeconds(2.1f);
        wall.material= wallBad;
        waking.WakingOn();
        yield return new WaitForSeconds(6.3f);
        waking.WakingOff();
        wall.material = wallGod;
        yield return new WaitForSeconds(0.15f);
        //lightSpot.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            eText.SetActive(true);
            into = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            eText.SetActive(false);
            into = false;
        }
    }
}
