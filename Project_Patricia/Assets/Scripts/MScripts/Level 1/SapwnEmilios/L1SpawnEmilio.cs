using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1SpawnEmilio : MonoBehaviour
{
    public ChildCry child;
    public int count, count2, count3;
    public GameObject emilio;
    public GameObject[] points;
    public bool spawn;
    public float time, maxTime;
    public GameObject[] tags;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            tags = GameObject.FindGameObjectsWithTag("Emilio");

            foreach (GameObject item in tags)
            {
                Destroy(item);
            }
        }

        child = FindObjectOfType<ChildCry>();
        if (child != null)
        {
            count = child.scream;
        }
        
        if(count==1)
        {
            if(count2<3)
            count2++;

            if (count == 1)
            {
                time += Time.deltaTime;

                if(time>maxTime)
                {
                    time = 0;

                    for (int i = 0; i < points.Length; i++)
                    {
                        Instantiate(emilio, points[i].transform.position, points[i].transform.rotation);
                    }
                }
            }
        }
                
    }

}
