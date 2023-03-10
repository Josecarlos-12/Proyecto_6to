using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public bool isPickable = true;

    public float rotation = 50;

    public bool trahs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerInteractionZone")
        {
            if(!trahs)
            {
                other.GetComponentInParent<PickUpObject>().ObjectToPickUp = this.gameObject;
                //Rotate();
            }            
        }

        if (other.tag == "PlayerInteractionZone")
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerInteractionZone")
        {
            if (!trahs)
            {
                other.GetComponentInParent<PickUpObject>().ObjectToPickUp = null;
            }
                
        }

        if (other.tag == "Desk")
        {

        }
    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.Keypad4))
        {
            transform.Rotate(new Vector3(0f, -rotation, 0f) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Keypad6))
        {
            transform.Rotate(new Vector3(0f, rotation, 0f) * Time.deltaTime);
        }
    }
}
