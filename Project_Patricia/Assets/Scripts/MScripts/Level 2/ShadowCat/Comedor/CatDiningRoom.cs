using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDiningRoom : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cat;
    [SerializeField] private float size, size2;
    [SerializeField] private int count, count2;
    [SerializeField] private Animator animCat;
    [SerializeField] private AudioSource scare;


    void Start()
    {
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        //Distance();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="DeEyes")
        {
            StartCoroutine("Cat");
        }
    }

    public IEnumerator Cat()
    {
        scare.Play();
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
    }

    public void Distance()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < size)
        { 
            if(count<3)
            count++;

            if (count == 1)
            {
                cat.SetActive(true);
            }
        }


        if (Vector3.Distance(transform.position, player.transform.position) < size2)
        {
            if (count2 < 3)
                count2++;

            if (count2 == 1)
            {
                animCat.SetBool("Save", true);
                StartCoroutine("DestroyCat");
            }
        }
    }

    public IEnumerator DestroyCat()
    {
        yield return new WaitForSeconds(0.30f);
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, size);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, size2);
    }
}
