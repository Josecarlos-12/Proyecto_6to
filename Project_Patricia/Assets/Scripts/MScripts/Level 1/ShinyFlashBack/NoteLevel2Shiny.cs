using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteLevel2Shiny : MonoBehaviour
{
    [SerializeField] private GameObject note;

    public void Note()
    {
        note.SetActive(true);
    }
}
