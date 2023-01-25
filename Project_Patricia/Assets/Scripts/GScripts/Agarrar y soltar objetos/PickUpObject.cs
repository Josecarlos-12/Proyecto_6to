using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject ObjectToPickUp;
    public GameObject PickedObject;
    public Transform interactionZone;

    [SerializeField] private Vector3 rotation;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ObjectToPickUp != null && ObjectToPickUp.GetComponent<PickableObject>().isPickable == true && PickedObject == null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickedObject = ObjectToPickUp;
                PickedObject.GetComponent<PickableObject>().isPickable = false;
                PickedObject.transform.SetParent(interactionZone);
                PickedObject.transform.position = interactionZone.position;
                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
                
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rotation = Vector3.up;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rotation = Vector3.down;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                rotation = Vector3.left;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                rotation = Vector3.right;
            }
            else
            {
                rotation = Vector3.zero;
            }

           
        }

        else if (PickedObject != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickedObject.GetComponent<PickableObject>().isPickable = true;
                PickedObject.transform.SetParent(null);
                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                PickedObject = null;

            }
        }

        transform.Rotate(rotation * speed * Time.deltaTime);
    }

}
