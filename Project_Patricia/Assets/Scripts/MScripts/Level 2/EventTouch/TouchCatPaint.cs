using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchCatPaint : MonoBehaviour
{
    [SerializeField] GameObject cat;
    [SerializeField] AudioSource audioSound;
    [SerializeField] AudioSource audioSound2;
    [SerializeField] Collider col;

    [Header("Chapter")]
    [SerializeField] GameObject cam;
    [SerializeField] GameObject chair;
    [SerializeField] GameObject prota, panel, text;


    public enum Cat
    {
        touch, chapter
    }
    public Cat type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (type)
            {
                case Cat.touch:
                    col.enabled = false;
                    audioSound.Play();
                    StartCoroutine("DesactiveCat");
                    break;
                case Cat.chapter:
                    col.enabled = false;
                    audioSound2.Play();
                    StartCoroutine("Chapter");
                    break;
            }

            
        }
    }

    public IEnumerator DesactiveCat()
    {   
        chair.SetActive(true);
        yield return new WaitForSeconds(1.1f);
        cat.SetActive(true);
        yield return new WaitForSeconds(1f);
        chair.SetActive(false);
        cat.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    public IEnumerator Chapter()
    {
        prota.SetActive(false);
        cam.SetActive(true);
        panel.SetActive(true);
        yield return new WaitForSeconds(1f);
        text.SetActive(true);
        yield return new WaitForSeconds(2f);
        //Cursor.visible= true;
        //Cursor.lockState= CursorLockMode.None;
        SceneManager.LoadScene("Nivel 3");
    }
}
