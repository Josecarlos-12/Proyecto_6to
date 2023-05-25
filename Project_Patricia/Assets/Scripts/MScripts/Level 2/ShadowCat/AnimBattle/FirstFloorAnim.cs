using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloorAnim : MonoBehaviour
{
    [SerializeField] private GameObject cam, prota, otherColl, camPos;
    [SerializeField] private Collider thisCol;

    [SerializeField] private GameObject wallFalse, doorCat;

    [SerializeField] private GameObject catContainer;
    [SerializeField] private SleepMode sleep;
    [SerializeField] LightInRoom room;


    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sleep.OffDreams();
            thisCol.enabled= false;
            cam.SetActive(true);
            prota.SetActive(false);
            otherColl.SetActive(false);
            catContainer.SetActive(false);
            Destroy(otherColl);

            for (int i = 0; i < room.down.Length; i++)
            {
                room.down[i].SetActive(true);
            }
        }
    }

    public void Finish()
    {
        prota.transform.position = camPos.transform.position;
        prota.transform.rotation = Quaternion.Euler(0,90,0);
        cam.SetActive(false);        
        wallFalse.SetActive(false);
        doorCat.GetComponent<Collider>().enabled = true;
        doorCat.GetComponent<Animator>().enabled= true;
        doorCat.GetComponent<OpenDoorM>().enabled= true;
        prota.SetActive(true);
    }
}
