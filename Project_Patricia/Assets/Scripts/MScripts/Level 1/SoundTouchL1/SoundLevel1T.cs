using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLevel1T : MonoBehaviour
{
    [SerializeField] private AudioSource sound;
    [SerializeField] private Collider col;
    [SerializeField] Animator animDoor;
    [SerializeField] AudioSource door;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sound.Play();
            col.enabled = false;
            StartCoroutine("DestroyObject");

            if(animDoor != null)
            {
                door.enabled= false;
                animDoor.SetBool("Front", false);
                animDoor.SetBool("Chi", false);
                animDoor.SetBool("Behind", true);
            }
        }        
    }

    public IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(20);
        Destroy(gameObject);
        if (animDoor != null)
        {
            door.enabled = true;
        }
    }
}
