using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cupboard : MonoBehaviour
{
    [SerializeField] private GameObject deer, prota, can, panel;
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
        if (bDeer && bProta)
        {
            anim.SetBool("On", true);
            StartCoroutine("Close");
        }
    }

    public IEnumerator Close()
    {
        yield return new WaitForSeconds(0.3f);
        panel.SetActive(true);
        prota.SetActive(false);
        can.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Nivel 1");
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
