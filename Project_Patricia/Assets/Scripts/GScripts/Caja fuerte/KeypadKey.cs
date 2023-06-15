using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadKey : MonoBehaviour
{
    public string key;
    public bool into;

    private void Update()
    {
        if(into && Input.GetMouseButtonDown(0))
        {
            SendKey();
        }
    }

    public void SendKey()
    {
        this.transform.GetComponentInParent<KeypadController>().PasswordEntry(key);
    }

    private void OnMouseOver()
    {
        into = true;
    }

    private void OnMouseExit()
    {
        into= false;
    }

}
