using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedPlay2 : MonoBehaviour
{
    public bool small, mediun, big;
    [SerializeField] private GameObject[] colls;
    public ContainerColliders container;


    private void Start()
    {
        container = FindObjectOfType<ContainerColliders>();
        colls[0] = container.small;
        colls[1] = container.mediun;
        colls[2] = container.big;
    }

    private void Update()
    {
        TrueColls();
    }

    public void TrueColls()
    {
        switch (col)
        {
            case coll.small:
                if (small && !colls[0].activeInHierarchy)
                {
                    small = false;
                }
                break;
            case coll.mediun:
                if (mediun && !colls[1].activeInHierarchy)
                {
                    mediun = false;
                }
                break;
            case coll.big:
                if (big && !colls[2].activeInHierarchy)
                {
                    big = false;
                }
                break;
        }
    }

    public enum coll
    {
        small, mediun, big
    }
    [SerializeField] private coll col;


    private void OnTriggerStay(Collider other)
    {
        switch (col)
        {
            case coll.small:
                if (other.gameObject.name == "Small")
                {
                    small = true;
                    Debug.Log("Toco el pequeño");
                }
                break;
            case coll.mediun:
                if (other.gameObject.name == "Mediun")
                {
                    mediun = true;
                    Debug.Log("Toco el del medio");
                }
                break;
            case coll.big:
                if (other.gameObject.name == "Big")
                {
                    big = true;
                    Debug.Log("Toco el grande");
                }
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (col)
        {
            case coll.small:
                if (other.gameObject.name == "Small")
                {
                    small = false;
                    Debug.Log("dejo de tocar el pequeño");
                }
                break;
            case coll.mediun:
                if (other.gameObject.name == "Mediun")
                {
                    mediun = false;
                    Debug.Log("dejo de tocar el del medio");
                }
                break;
            case coll.big:
                if (other.gameObject.name == "Big")
                {
                    big = false;
                    Debug.Log("dejo de tocar el grande");
                }
                break;
        }
    }
}
