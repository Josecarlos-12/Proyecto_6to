using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int Code;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Tacto");
            List<Keys> a = other.gameObject.GetComponent<PlayerActions>().KeyInventory;
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i].DoorCode == Code)
                {
                    a[i].Obteind = true;
                    Debug.Log("llave Obtenida");
                }
            }
            Destroy(this.gameObject);
        }
    }
}
