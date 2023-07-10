using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLevel1T : MonoBehaviour
{
    [SerializeField] private AudioSource sound;
    [SerializeField] private Collider col;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sound.Play();
            col.enabled = false;
            StartCoroutine("DestroyObject");
        }        
    }

    public IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
