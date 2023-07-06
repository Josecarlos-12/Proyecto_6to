using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillsDesative : MonoBehaviour
{
    [SerializeField] private GameObject one, two, three;

    private void Update()
    {
        if(one == null && two==null && three == null)
        {
            Destroy(gameObject);
        }
    }

}
