using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRifleColl : MonoBehaviour
{
    public GameObject cam, prota, capsuleBlack, positon, chain;
    [SerializeField] private Animator door;
    [SerializeField] private int count;
    [SerializeField] private Animator doorBoss;
    [SerializeField] private TasksUI task;
    [SerializeField] private GameObject limit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(count<3)
            count++;

            if (count == 1)                
            {
                Destroy(limit);
                task.taskCount = 2;
                chain.SetActive(false);
                door.SetBool("Open", true);
                prota.SetActive(false);
                cam.SetActive(true);
                StartCoroutine("Finish");
                capsuleBlack.SetActive(true);
                doorBoss.SetBool("On", true);
                prota.transform.position= new Vector3(positon.transform.position.x, 4.212376f, positon.transform.position.z);
                prota.transform.rotation= positon.transform.rotation;
            }
        }
    }


    public IEnumerator Finish()
    {
        yield return new WaitForSeconds(8);
        door.SetBool("Open", false);       
    }
}
