using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrouchTutorial : MonoBehaviour
{
    [SerializeField] PlayerCrouch crouch;
    [SerializeField] GameObject text;
    [SerializeField] int count;
    public bool active;

    void Update()
    {
        if (crouch.crouch && active)
        {

            if(count<3)
            count++;


            if (count == 1)
            {
                StartCoroutine("Dialogue");
            }

            
        }
    }



    public IEnumerator Dialogue()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Shh...";
        yield return new WaitForSeconds(1.5f);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Silencio";
        yield return new WaitForSeconds(1.5f);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Despacio..";
        yield return new WaitForSeconds(1.5f);
        text.SetActive(false);
    }
}
