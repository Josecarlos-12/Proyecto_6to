using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimPunch : MonoBehaviour
{
    [SerializeField] private GameObject cam, prota, panel, chapter1;
    [SerializeField] private AudioSource chapterAudio, horror;
    [SerializeField] private AudioClip clip;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            prota.SetActive(false);
            cam.SetActive(true);
            horror.Play();
            StartCoroutine("ChapterOne");
        }
    }

    public IEnumerator ChapterOne()
    {
        yield return new WaitForSeconds(2.4f);
        panel.SetActive(true);
        yield return new WaitForSeconds(2f);
        chapter1.SetActive(true);
        chapterAudio.Play();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Nivel 1");
    }

    public void Punch()
    {
        horror.clip = clip;
        horror.Play();
    }
}
