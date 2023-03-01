using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrongBox : MonoBehaviour
{
    [SerializeField] private Collider col;
    [SerializeField] private GameObject text;
    [SerializeField] private Text pasword;
    [SerializeField] private bool into;
    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E))
        {
            pasword.text = "2604";
            text.SetActive(false);
            col.enabled = false;
            anim.SetBool("Close", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(true);
            into = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(false);
            into = false;
        }
    }
}
