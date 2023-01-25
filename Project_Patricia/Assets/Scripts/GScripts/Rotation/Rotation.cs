using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private Vector3 rotation;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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

        transform.Rotate(rotation * speed * Time.deltaTime);
    }
}
