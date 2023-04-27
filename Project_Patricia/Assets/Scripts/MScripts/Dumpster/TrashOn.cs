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

    [SerializeField] private GameObject player;
    [SerializeField] private float sizePlayer = 7;
    public int countPlayer;


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

        DetectedPlayer();
    }

    public void DetectedPlayer()
    {
        if(player!= null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < sizePlayer)
            {
                if (countPlayer < 3)
                    countPlayer++;
            }
        }       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, size);
    }
}
