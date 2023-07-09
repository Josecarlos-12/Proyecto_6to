using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTerrazaTuto : MonoBehaviour
{
    [SerializeField] private Animator animDoor;
    [SerializeField] private AudioSource audiDoor;
    [SerializeField] private AudioClip clip;
    [SerializeField] private Collider thisCol;
    [SerializeField] private GameObject otherCol;
    public enum State
    {
        one, two
    }
    public State state;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            switch (state)
            {
                case State.one:
                    audiDoor.clip = clip;
                    audiDoor.Play();
                    audiDoor.loop = true;
                    thisCol.enabled = false;
                    animDoor.SetBool("Chi", true);
                    Destroy(otherCol);
                    Destroy(gameObject);
                    break; 
                case State.two:
                    animDoor.SetBool("Chi", false);
                    audiDoor.Stop();
                    audiDoor.loop = false;
                    Destroy(gameObject);
                    break;
            }

            
        }
    }

}
