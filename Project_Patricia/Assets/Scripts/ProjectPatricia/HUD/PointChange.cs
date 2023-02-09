using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointChange : MonoBehaviour
{
    public int Code;
    //puede ponerse en cualquier objeto que tenga el Script de MisionHUD
    public GameObject MisHUD_;
    MisionHUD Mh;
    private void Awake()
    {
        Mh = MisHUD_.GetComponent<MisionHUD>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Mh.NotaList[Mh.NotaNumber].Point == this.gameObject) {
            Mh.NotaNumber += 1;
            Mh.ChangeNumber(true);
            Destroy(this.gameObject);
        }
    }
}
