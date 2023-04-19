using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EventKeyShadow : MonoBehaviour
{
    public bool canRifle;
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject key;
    [SerializeField] private Collider col;
    [SerializeField] private bool into;
    [SerializeField] private Color color;
    [SerializeField] private float time, maxTime, alpha;
    [SerializeField] private int count;
    [SerializeField] private Animator anim, animKey;
    [SerializeField] private EventKeyShadow keyS;

    [Header("trasparency")]
    [SerializeField] private MeshRenderer render;
    [SerializeField] private Color myColor;
    [SerializeField, Range(0, 1)] private float myAlpha;

    [Header("Call Other Script")]
    [SerializeField] private Inventary inventary;
    [SerializeField] private Weapon weapon;

    [Header("kinematics")]
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator animCine;
    [SerializeField] private int countAnim;


    private void Start()
    {
    }

    private void Update()
    {

        if(canRifle == true && weapon.save)
        {
            anim.SetBool("Change", false);
            //keyS.enabled = false;

            if(countAnim<3)
            countAnim++;

            if (countAnim == 1)
            {
                StartCoroutine("DialogueRifle");
            }
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            col.enabled= false;
            StartCoroutine("Dialogue");
        }   
    }


    public IEnumerator DialogueRifle()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Hablo en serio!";
        yield return new WaitForSeconds(2);
        animCine.enabled= true;
        text.SetActive(false);
        cam.SetActive(true);
        player.SetActive(false);
        yield return new WaitForSeconds(1f);
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Charlie Schmith: ¡Papaaaaaaaaaaaa!";
        yield return new WaitForSeconds(5);
        text.SetActive(false);
    }

    public IEnumerator Destroy()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Déjame ver a mi hijo!";
        yield return new WaitForSeconds(2);
        text.SetActive(false);
        yield return new WaitForSeconds(2);
        inventary.rifle = true;
        inventary.bPills = false;
        inventary.bKeyComfi = false;
        canRifle= true;
        anim.SetBool("Change", true);
        Destroy(key);
    }

    public IEnumerator Dialogue()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡¿Qué quieres?! ¡¿Qué haces aquí?!";
        yield return new WaitForSeconds(3);
        text.SetActive(false);
        animKey.enabled = true;
    }
}
