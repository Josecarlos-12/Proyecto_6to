using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInRoom : MonoBehaviour
{
    public GameObject[] lgth;
    public int randon;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < lgth.Length; i++)
        {
            lgth[i].SetActive(false);
        }
        StartCoroutine(NextLight());
    }   

    public IEnumerator NextLight()
    {
        yield return new WaitForSeconds(0);
        randon = Random.Range(0, 5);
        lgth[randon].SetActive(true);
        Debug.Log("Prendio: " + randon);
        yield return new WaitForSeconds(10);
        lgth[randon].SetActive(false);
        yield return NextLight();
    }
}
