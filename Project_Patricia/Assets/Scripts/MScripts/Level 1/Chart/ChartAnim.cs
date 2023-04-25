using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartAnim : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public bool into, activeCap;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject text, prota, camaraAnim;

    void Update()
    {
        InputPress();
    }

    public void InputPress()
    {
        if(Input.GetKeyDown(KeyCode.E) && into)
        {
            col.enabled= false;
            into= false;
            text.SetActive(false);
            prota.SetActive(false);
            camaraAnim.SetActive(true);
            anim.SetBool("Chart", true);
            StartCoroutine(ActiveProta());
        }
    }

    public IEnumerator ActiveProta()
    {
        prota.SetActive(false);
        camaraAnim.SetActive(true);
        yield return new WaitForSeconds(4f);
        prota.SetActive(true);
        camaraAnim.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(true);
            into= true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(false);
            into= false;
        }
    }
}
