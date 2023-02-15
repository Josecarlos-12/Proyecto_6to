using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public int range;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
        {
            if(hit.collider.GetComponent<Interact>() == true)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(hit.collider.GetComponent<Interact>().luz == true)
                    {
                        hit.collider.GetComponent<Interact>().OnOffLight();
                    }
                }    
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * range);
    }
}
