using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPlayMusic : MonoBehaviour
{
    [SerializeField] bool into;
    [SerializeField] GameObject text;
    [SerializeField] Animator handle;
    [SerializeField] Collider col;
    [SerializeField] BoxMusicInteractions box;
    public bool animBox;

    [Header("Note")]
    [SerializeField] private GameObject note;
    [SerializeField] private Animator drawer, noteAnim;
    [SerializeField] private Collider colDrawer;
    public bool on;

    void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E))
        {
            animBox = true;
            box.Dream();
            col.enabled = false;
            text.SetActive(false);
            into = false;
            handle.SetBool("Handle", true);
            box.audi.Play();
            StartCoroutine("Code1");
        }
    }

    public IEnumerator Code1()
    {
        yield return new WaitForSeconds(1.7f);
        on = true;
        note.SetActive(true);
        drawer.SetBool("On", true);
        noteAnim.SetBool("On", true);
        yield return new WaitForSeconds(0.3f);
        colDrawer.enabled = true;
        yield return new WaitForSeconds(4);
        drawer.SetBool("On", false);
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
