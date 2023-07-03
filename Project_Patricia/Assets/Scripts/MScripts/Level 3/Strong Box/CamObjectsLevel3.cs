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
    [SerializeField] private GameObject[] one, two, three, four;

    [Header("Start Animation")]
    [SerializeField] private GameObject camAnim;
    [SerializeField] private bool bOne, bTwo, bThree, bFour;
    [SerializeField] private int count;
    [SerializeField] private Collider col;
    [SerializeField] private Animator animObjects;
    [SerializeField] private bool press;
    [SerializeField] private GameObject texE;


    private void Update()
    {
        if (into && Input.GetKeyDown(KeyCode.E))
        {
            animObjects.SetBool("On", false);
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
            
            if (objectCount > 3)
            {
                objectCount = 0;
            }
        }
        if (viewObjects && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
            objectCount--;
            
            if (objectCount < 0)
            {
                objectCount = 3;
            }
        }

        if(press && Input.GetKeyDown(KeyCode.E))
        {
            texE.SetActive(false);
            press = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cam.SetActive(false);
            camAnim.SetActive(true);
            col.enabled = false;
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
            one[3].SetActive(true);

            //2
            two[0].SetActive(false);
            two[1].SetActive(false);
            two[2].SetActive(false);
            two[3].SetActive(false);

            //3
            three[0].SetActive(false);
            three[1].SetActive(false);
            three[2].SetActive(false);
            three[3].SetActive(false);

            //4
            four[0].SetActive(false);
            four[1].SetActive(false);
            four[2].SetActive(false);
            four[3].SetActive(false);
        }
        else if (objectCount == 1)
        {
            bTwo= true;

            //1
            one[0].SetActive(false);
            one[1].SetActive(false);
            one[2].SetActive(false);
            one[3].SetActive(false);

            //2
            two[0].SetActive(true);
            two[1].SetActive(true);
            two[2].SetActive(true);
            two[3].SetActive(true);

            //3
            three[0].SetActive(false);
            three[1].SetActive(false);
            three[2].SetActive(false);
            three[3].SetActive(false);

            //4
            four[0].SetActive(false);
            four[1].SetActive(false);
            four[2].SetActive(false);
            four[3].SetActive(false);
        }
        else if (objectCount ==2)
        {
            bThree= true;

            //1
            one[0].SetActive(false);
            one[1].SetActive(false);
            one[2].SetActive(false);
            one[3].SetActive(false);

            //2
            two[0].SetActive(false);
            two[1].SetActive(false);
            two[2].SetActive(false);
            two[3].SetActive(false);

            //3
            three[0].SetActive(true);
            three[1].SetActive(true);
            three[2].SetActive(true);
            three[3].SetActive(true);

            //4
            four[0].SetActive(false);
            four[1].SetActive(false);
            four[2].SetActive(false);
            four[3].SetActive(false);
        }
        else if (objectCount==3)
        {
            bFour= true;

            //1
            one[0].SetActive(false);
            one[1].SetActive(false);
            one[2].SetActive(false);
            one[3].SetActive(false);

            //2
            two[0].SetActive(false);
            two[1].SetActive(false);
            two[2].SetActive(false);
            two[3].SetActive(false);

            //3
            three[0].SetActive(false);
            three[1].SetActive(false);
            three[2].SetActive(false);
            three[3].SetActive(false);

            //4
            four[0].SetActive(true);
            four[1].SetActive(true);
            four[2].SetActive(true);
            four[3].SetActive(true);
        }
    }

    public void Animation()
    {
        if (bOne && bTwo && bThree && bFour)
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
        yield return new WaitForSeconds(3);
        press = true;
        texE.SetActive(true);        
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
