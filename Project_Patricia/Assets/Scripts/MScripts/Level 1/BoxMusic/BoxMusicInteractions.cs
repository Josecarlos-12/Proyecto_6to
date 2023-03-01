using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMusicInteractions : MonoBehaviour
{

    public bool open;
    [SerializeField] Animator anim;
    [SerializeField] PickableObject pick, pick2;
    [SerializeField] TrashOn trashOne;
    public NotesUI note;
    [SerializeField] private int count;
    [SerializeField] private AudioSource audi;
    [SerializeField] private int cDream;
    [SerializeField] private SleepMode sleep;


    public enum Work
    {
        tras, shopping, firewood, boxMusic
    }
    public Work word;

    private void Start()
    {
        open = true;
    }

    void Update()
    {
        if (trashOne.into)
        {
            if (count < 3)
                count++;

            if (count == 1)
            {
                switch (word)
                {
                    case Work.tras:
                        note.check = 1;
                        anim.SetBool("Open", true);
                        break;
                    case Work.shopping:
                        note.check = 2;
                        break;
                    case Work.firewood:
                        note.check = 8;
                        break;
                        case Work.boxMusic:
                        audi.Play();
                        Dream();
                        break;
                }
            }
        }
    }

    public void Dream()
    {
        if(cDream<3)
        cDream++;

        if (cDream == 1)
        {
            StartCoroutine("IEDream");
        }
    }

    public IEnumerator IEDream()
    {
        yield return new WaitForSeconds(3);
        sleep.ModeDreams();
    }
}
