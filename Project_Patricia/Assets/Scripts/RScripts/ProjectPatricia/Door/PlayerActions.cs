using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{
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
        }
    }
    private void Update()
    {
        
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

