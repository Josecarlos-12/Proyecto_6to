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
        text.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Shh... Silencio... Despacio..";
        yield return new WaitForSeconds(2f);
        text.SetActive(false);
    }
}
