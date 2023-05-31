using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainCatShed : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BulletPlayer"))
        {
            this.gameObject.GetComponent<Animator>().SetBool("On", false);
            Destroy(other.gameObject);
            rb.isKinematic= false;
            rb.useGravity= true;
            door.SetActive(true);
            this.gameObject.GetComponent<ChainCatShed>().enabled= false;
        }
    }
}
