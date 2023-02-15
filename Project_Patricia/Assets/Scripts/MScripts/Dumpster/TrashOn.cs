using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashOn : MonoBehaviour
{
    [SerializeField] private PickableObject pick;
    [SerializeField] private Transform position;
    [SerializeField] private DumpsterInteraction dum;
    [SerializeField] private Collider col;
    [SerializeField] private Rigidbody rbd;
    [SerializeField] private bool touch;
    public bool into;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(touch)
        {
            if (pick.isPickable && dum.open)
            {
                col.enabled = false;
                transform.position = position.position;
                transform.rotation = position.rotation;
                pick.isPickable= false;
                rbd.useGravity = false;
                rbd.isKinematic = true;
                into = true;
            }
        }  
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Throw")
        {
            touch = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Throw")
        {
            touch= false;
            if (!pick.isPickable)
            {

            }
        }
    }
}
