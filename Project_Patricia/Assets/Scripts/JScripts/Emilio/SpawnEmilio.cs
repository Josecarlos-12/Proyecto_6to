using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEmilio : MonoBehaviour
{
    public GameObject[] emilio;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.F) )
        {
            for ( int i = 0; i < emilio.Length; i++ )
            {
                Instantiate(prefab, emilio[i].transform.position, emilio[i].transform.rotation);
            }
        }
    }
}
