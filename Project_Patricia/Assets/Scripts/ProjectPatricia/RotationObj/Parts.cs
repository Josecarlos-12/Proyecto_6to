using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : MonoBehaviour
{
    public int Code;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            List<PartMusical> a = other.gameObject.GetComponent<PlayerActions>().Parts;
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i].Code == Code)
                {
                    a[i].Obteind = true;
                    a[i].Part.SetActive(true);
                    Debug.Log("Pieza musical obtenida " + a[i].Part );
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
