using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject ObjectToPickUp;
    public GameObject PickedObject;
    public Transform interactionZone;

    [SerializeField] private Vector3 rotation;
    [SerializeField] private float speed;

    [SerializeField] private CharacterController player;
    public Vector3 newCenter;
    public float newRadius;
    public float timer;

    [SerializeField] private bool door;

    [Header("Shiny")]
    [SerializeField] private GameObject shelf, shelfTwo;
    [SerializeField] private Animator animShelf, animShelfTwo;

    // Start is called before the first frame update
    void Start()
    {
        //newRadius=player.radius;
        //newCenter = player.center;
        //Debug.Log(player.center);
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
                //newCenter = new Vector3(0,0,0.2f);
                newRadius = 0.7f;
                timer = 0;

                if (shelf != null)
                {
                    if (shelf == ObjectToPickUp)
                    {
                        animShelf.SetBool("On", true);
                    }
                    if (shelfTwo == ObjectToPickUp)
                    {
                        animShelfTwo.SetBool("On", true);
                    }
                }
                


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
            if (Input.GetKeyDown(KeyCode.E) && !door)
            {
                PickedObject.GetComponent<PickableObject>().isPickable = true;
                PickedObject.transform.SetParent(null);
                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                PickedObject = null;
                newCenter = new Vector3(0,0,0);
                newRadius = 0.5f;
                timer = 0;


                if (shelf != null)
                {
                    animShelf.SetBool("On", false);
                    animShelfTwo.SetBool("On", false);

                }
                
            }
        }

        transform.Rotate(rotation * speed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        //player.radius = Mathf.Lerp(player.radius, newRadius, timer);
        //7player.center = Vector3.Lerp(player.center, newCenter, timer);
        //timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            door = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            door= false;
        }
    }

}
