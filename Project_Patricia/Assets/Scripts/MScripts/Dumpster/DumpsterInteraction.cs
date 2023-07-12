using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpsterInteraction : MonoBehaviour
{
    public bool open;
    [SerializeField] Animator anim;
    [SerializeField] PickableObject pick, pick2;
    [SerializeField] TrashOn trashOne, trashTwo;
    public NotesUI note;
    [SerializeField] private int count;
    public AudioSource closeAudio;
    public AudioClip dumpster;
    [SerializeField] private AudioSource finish;
    [SerializeField] private float time;
    [SerializeField] private GameObject rabbit, rabbitBad;

    public enum Work
    {
        trash, shopping, firewood
    }
    public Work word;

    private void Start()
    {
        open = true;
    }

    void Update()
    {
        if(trashOne.into && trashTwo.into)
        {
            if(count<3)
            count++;

            if (count == 1)
            {
                StartCoroutine("Sound");
                switch (word)
                {
                    case Work.trash:
                        note.check = 1;
                        anim.SetBool("Open", true);
                        closeAudio.PlayOneShot(dumpster);
                        break;
                    case Work.shopping:
                        note.check = 2;
                        break;
                    case Work.firewood:
                        rabbit.SetActive(true);
                        rabbitBad.SetActive(false);
                        note.check = 8;
                    break;
                }
            }                      
        }
    }

    public IEnumerator Sound()
    {
        yield return new WaitForSeconds(time);
        finish.Play();
    }
}
