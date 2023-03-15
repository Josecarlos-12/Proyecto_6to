using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartAnim : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public bool into, activeCap;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject text, prota, camaraAnim, cap;

    [Header("Walk Sound")]
    [SerializeField] private GameObject soundObject;
    [SerializeField] private AudioSource walkSound;
    [SerializeField] private AudioClip doorClip;

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
        yield return new WaitForSeconds(1.45f);
        prota.SetActive(true);
        camaraAnim.SetActive(false);
        soundObject.SetActive(true);
        yield return new WaitForSeconds(7f);
        walkSound.Pause();
        yield return new WaitForSeconds(0.3f);
        walkSound.clip= doorClip;
        walkSound.loop = false;
        walkSound.Play();
        cap.SetActive(true);
        activeCap = true;
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
