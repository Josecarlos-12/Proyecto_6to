using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashOn : MonoBehaviour
{
    [SerializeField] private PickableObject pick;
    [SerializeField] private Transform position;
    [SerializeField] private Collider col;
    [SerializeField] private Rigidbody rbd;
    [SerializeField] private bool touch;
    public bool into;
    [SerializeField] public Transform objectGarbage;
    [SerializeField] private float size;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector3.Distance(transform.position, objectGarbage.position) < size)
        {
            if (pick.isPickable)
            {
                col.enabled = false;
                transform.position = position.position;
                transform.rotation = position.rotation;
                pick.isPickable = false;
                rbd.useGravity = false;
                rbd.isKinematic = true;
                into = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, size);
    }
}
