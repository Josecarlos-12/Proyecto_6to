using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerLevel3 : MonoBehaviour
{
    [SerializeField] private GameObject eyes, houseGod, houseBad;
    [SerializeField] private GameObject[] boxForte;
    [SerializeField] private Animator box, eyes2;
    [SerializeField] private WakingUpMode waking;
    [SerializeField] private Collider col;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            col.enabled = false;
            
            StartCoroutine("Dialogue");
        }
    }

    public IEnumerator Dialogue()
    {        
        box.SetBool("On", true);
        yield return new WaitForSeconds(3);
        eyes.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        boxForte[0].SetActive(false);
        boxForte[1].SetActive(false);
        houseGod.SetActive(true);
        houseBad.SetActive(false);        
        waking.WakingOff();
        eyes2.SetBool("Open", true);
    }

}
