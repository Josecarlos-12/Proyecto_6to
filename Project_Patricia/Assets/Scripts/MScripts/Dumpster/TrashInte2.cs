using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
                note.check = 1;
                anim.SetBool("Open", true);
                closeAudio.PlayOneShot(dumpster);
            }
        }
    }

    public IEnumerator Sound()
    {
        yield return new WaitForSeconds(1.5f);
        finish.Play();
    }
}
