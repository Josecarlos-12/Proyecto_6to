using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cupboard : MonoBehaviour
{
    [SerializeField] private GameObject deer, prota, can, panel;
    [SerializeField] private GameObject nextChapter, text;
    [SerializeField] private bool bDeer, bProta;
    [SerializeField] private float sizeDeer, sizeProta;
    [SerializeField] private Animator anim;
    [SerializeField] private int count;
    [SerializeField] private EnemyShed enemy;
    [SerializeField] private AudioSource audioFinish, audioMike;
    [SerializeField] private AudioClip clip;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Distance();
        Animation();
    }

    public void Animation()
    {
        if (bDeer && bProta)
        {
            if(count < 3)
            count++;

            if (count == 1)
            {
                StartCoroutine("Close");
            }
            
        }
    }

    public IEnumerator Close()
    {
        audioMike.clip = clip;
        audioMike.Play();
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: ¡Ya te tengo!";
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
        anim.SetBool("On", false);
        yield return new WaitForSeconds(0.3f);
        panel.SetActive(true);
        prota.SetActive(false);
        can.SetActive(true);
        yield return new WaitForSeconds(2f);
        audioFinish.Play();
        nextChapter.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Nivel 1");
    }

    public void Distance()
    {
        if(Vector3.Distance(transform.position, deer.transform.position) < sizeDeer)
        {
            bDeer= true;
            enemy.run2 = false;
            enemy.anim.SetBool("Walk", false);
            enemy.anim.SetBool("Run", false);
        }
        else
        {
            bDeer= false;
        }

        if (Vector3.Distance(transform.position, prota.transform.position) < sizeProta)
        {
            bProta= true;
        }
        else
        {
            bProta= false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sizeProta);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sizeDeer);
    }
}
