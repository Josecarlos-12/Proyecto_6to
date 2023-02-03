using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{
    [Header("Door Interact")]
    public GameObject boxText;
    [SerializeField]
    public Transform Camera;
    [SerializeField]
    public float MaxUseDistance = 5f;
    [SerializeField]
    public LayerMask UseLayers;
    public KeyCode DoorInteract = KeyCode.E;
    public List<Keys> KeyInventory = new List<Keys>();
    public bool permitido;

    [Header("OpenPopUp Interact")]
    public KeyCode OpenPopUp = KeyCode.P;
    //todos los objetos
    public GameObject CanCamera;
    //El objeto que se rota
    public List<GameObject> ObjRotation = new List<GameObject>();
    [SerializeField] bool act;

    [Header("Palanca Interact")]
    public KeyCode PalancaInteract = KeyCode.O;

    [Header("Part Musical")]
    public List<PartMusical> Parts = new List<PartMusical>();


    public void OnUse()
    {
        if(Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, UseLayers))
        {
            if(hit.collider.TryGetComponent<DoorScripts>(out DoorScripts door))
            {
                if (door.IsOpen)
                {
                    door.Close();
                }
                else
                {
                    door.Open(transform.position);
                }
            }
            if (hit.collider.TryGetComponent<Palanca>(out Palanca pal))
            {
                if (pal.State == Palanca.PalancaState.ON || pal.State == Palanca.PalancaState.Off)
                {
                    pal.State = Palanca.PalancaState.Move;
                }
            }
        }
    }
    private void Update()
    {
        #region Door
        if (Input.GetKeyDown(DoorInteract) && permitido)
        {
            OnUse();
        }
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, UseLayers) 
            && hit.collider.TryGetComponent<DoorScripts>(out DoorScripts door))
        {
            boxText.SetActive(true);
            SearchKey(door);
            Debug.Log("Detect2");
        }
        else
        {
            boxText.SetActive(false);
            permitido = false;
        }
        #endregion

        #region PopUp
        if (Input.GetKeyDown(OpenPopUp) & act)
        {
            CanCamera.SetActive(false);
            act = false;
        }
        else if (Input.GetKeyDown(OpenPopUp) & !act)
        {
            CanCamera.SetActive(true);
            if(ObjRotation.Count > 0)
            for(int i = 0; i < ObjRotation.Count; i++)
            {
                ObjRotation[i].transform.rotation = Quaternion.identity;
                Rigidbody rt = ObjRotation[i].GetComponent<Rigidbody>();
                rt.isKinematic = true;
                rt.isKinematic = false;
                act = true;
            }
        }
        #endregion

        #region Palanca
        if (Input.GetKeyDown(PalancaInteract))
        {
            OnUse();
        }
        #endregion
    }
    void SearchKey(DoorScripts or)
    {
        for (int i = 0; i < KeyInventory.Count; i++){
            if(KeyInventory[i].DoorCode == or.doorCode
                && KeyInventory[i].Obteind)
            {
                Debug.Log("Si tiene llave");
                permitido =true;
            }
        }
    }


}




[Serializable]
public class Keys
{
    public int DoorCode;
    public bool Obteind;
}

[Serializable]
public class PartMusical
{
    public int Code;
    public bool Obteind;
    public GameObject Part;
}

