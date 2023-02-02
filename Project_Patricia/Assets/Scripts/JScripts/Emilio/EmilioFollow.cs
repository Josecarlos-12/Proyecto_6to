using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class EmilioFollow : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    [SerializeField] private bool bDetection;
    [SerializeField] private int count;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    public void Follow()
    {
        if (!bDetection)
        {
            agent.destination = player.transform.position;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (count == 0)
        {
            if (other.gameObject.name == "DeEyes")
            {
                count++;
                bDetection = true;
                print("Toco ojos");
            }
            if (other.gameObject.name == "DeRadius")
            {
                count++;
                bDetection = false;
                print("Toco Radio");
            }
        }        
    }
}
