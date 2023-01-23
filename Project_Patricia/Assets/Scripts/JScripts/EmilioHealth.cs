using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmilioHealth : MonoBehaviour
{

    public float health = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( health <= 0 )
        {
            Destroy( gameObject );
        }
        if ( health > 1 )
        {
            health = 1;
        }
    }
}
