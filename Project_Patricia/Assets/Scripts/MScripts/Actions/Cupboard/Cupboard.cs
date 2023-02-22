using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cupboard : MonoBehaviour
{
    [SerializeField] private GameObject deer, prota;
    [SerializeField] private bool bDeer, bProta;
    [SerializeField] private float sizeDeer, sizeProta;
    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Distance();
        Animation();
    }

    public void Animation()
    {
        if(bDeer && bProta) 
        {
            anim.SetBool("On", true);
        }
    }

    public void Distance()
    {
        if(Vector3.Distance(transform.position, deer.transform.position) < sizeDeer)
        {
            bDeer= true;
        }
        else
        {
            bDeer= false;
        }

        if (Vector3.Distance(transform.position, prota.transform.position) < sizeProta)
        {
            bProta= true;
        }
        else
        {
            bProta= false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sizeProta);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sizeDeer);
    }
}
