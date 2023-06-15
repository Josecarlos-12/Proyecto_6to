using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamObjectsLevel3 : MonoBehaviour
{
    [SerializeField] private GameObject cam, prota;
    [SerializeField] private GameObject eText;
    [SerializeField] private bool into, viewObjects;

    [Header("Objects")]
    [SerializeField] private int objectCount = 0;
    [SerializeField] private GameObject[] one, two, three;

    [Header("Start Animation")]
    [SerializeField] private GameObject camAnim;
    [SerializeField] private bool bOne, bTwo, bThree;
    [SerializeField] private int count;
    [SerializeField] private Collider col;


    private void Update()
    {
        if (into && Input.GetKeyDown(KeyCode.E))
        {
            into= false; 
            eText.SetActive(false);
            viewObjects= true;
            cam.SetActive(true);
            prota.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        Animation();
        ObjectsRotate();

        if (viewObjects && Input.GetKeyDown(KeyCode.RightArrow))
        { 
            objectCount++;
            
            if (objectCount > 2)
            {
                objectCount = 0;
            }
        }
        if (viewObjects && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
            objectCount--;
            
            if (objectCount < 0)
            {
                objectCount = 2;
            }
        }

    }

    public void ObjectsRotate()
    {
        if (objectCount == 0)
        {
            bOne = true;

            //1
            one[0].SetActive(true);
            one[1].SetActive(true);
            one[2].SetActive(true);

            //2
            two[0].SetActive(false);
            two[1].SetActive(false);
            two[2].SetActive(false);

            //3
            three[0].SetActive(false);
            three[1].SetActive(false);
            three[2].SetActive(false);
        }
        else if (objectCount == 1)
        {
            bTwo= true;

            //1
            one[0].SetActive(false);
            one[1].SetActive(false);
            one[2].SetActive(false);

            //2
            two[0].SetActive(true);
            two[1].SetActive(true);
            two[2].SetActive(true);

            //3
            three[0].SetActive(false);
            three[1].SetActive(false);
            three[2].SetActive(false);
        }
        else if (objectCount ==2)
        {
            bThree= true;

            //1
            one[0].SetActive(false);
            one[1].SetActive(false);
            one[2].SetActive(false);

            //2
            two[0].SetActive(false);
            two[1].SetActive(false);
            two[2].SetActive(false);

            //3
            three[0].SetActive(true);
            three[1].SetActive(true);
            three[2].SetActive(true);
        }
    }

    public void Animation()
    {
        if (bOne && bTwo && bThree)
        { 
            if(count<3)
            count++;

            if(count ==1)
            {
                StartCoroutine("AnimTrue");
            }
        }
    }

    public IEnumerator AnimTrue()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        yield return new WaitForSeconds(2);
        cam.SetActive(false);
        camAnim.SetActive(true);
        col.enabled = false;
    }

    private void OnTriggerStay(Collider other)
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
