using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrashInte2 : MonoBehaviour
{
    [SerializeField] TrashOn trashOne;
    [SerializeField] private int count;
    [SerializeField] private AudioSource finish;
    public AudioSource closeAudio;
    [SerializeField] Animator anim;
    public NotesUI note;
    public AudioClip dumpster;


    void Update()
    {
        if (trashOne.into)
        {
            if (count < 3)
                count++;

            if (count == 1)
            {
                StartCoroutine("Sound");
                note.check = 2;
            }
        }
    }

    public IEnumerator Sound()
    {
        yield return new WaitForSeconds(0.5f);
        finish.Play();
    }
}
