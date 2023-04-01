using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRifleColl : MonoBehaviour
{
    [SerializeField] private GameObject cam, prota;
    [SerializeField] private Animator door;
    [SerializeField] private int count;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(count<3)
            count++;

            if (count == 1)
            {
                door.SetBool("Open", true);
                prota.SetActive(false);
                cam.SetActive(true);
                StartCoroutine("Finish");
            }
        }
    }


    public IEnumerator Finish()
    {
        yield return new WaitForSeconds(8);
        door.SetBool("Open", false);
        yield return new WaitForSeconds(9);
        prota.SetActive(true);
        cam.SetActive(false);
    }
}
