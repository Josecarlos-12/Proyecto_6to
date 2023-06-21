using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NotePopUp2 : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    [SerializeField] private Camera cam;
    [SerializeField] private NoteInteraction note;
    public NotesUI noteList;
    [SerializeField] private string cod;
    [SerializeField] private Sprite spri;

    [Header("Player")]
    [SerializeField] private GameObject camGame;
    [SerializeField] private GameObject player;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000, layer))
            {
                if (hit.transform.CompareTag("Note"))
                {
                    cod = note.noteText;
                    spri = note.image;

                    noteList.sNote.Add(spri);
                    noteList.traducttionNote.Add(cod);

                    print("Toco nota");
                    Destroy(hit.transform.gameObject);

                    camGame.SetActive(false);
                    player.SetActive(true);

                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }
    }
}
