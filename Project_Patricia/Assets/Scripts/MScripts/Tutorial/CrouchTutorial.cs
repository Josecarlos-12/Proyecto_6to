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
        if (crouch.crouch)
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
        yield return new WaitForSeconds(2);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Silencio";
        yield return new WaitForSeconds(2);
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Despacio..";
    }
}
