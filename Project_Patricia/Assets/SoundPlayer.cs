using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip Ghost;
    public float repeatTime;

    public AudioSource ghostBreathing;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(PlaySound), 0f, repeatTime);
    }

    private void PlaySound()
    {
        ghostBreathing.PlayOneShot(Ghost);
    }
}
