using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MisionHUD : MonoBehaviour
{
    public GameObject Nota;
    bool NotaActive = true;
    public int NotaNumber;
    public TMP_Text TMP_texto;
    [SerializeField] float Timer;
    [SerializeField] float MaxTimer = 5;
    public List<NotaText> NotaList = new List<NotaText>();
    public GameObject Guide;
    void Start()
    {
        TMP_texto.text = NotaList[0].Text;

        if(NotaList.Count > 1)
        for(int i = 0; i < NotaList.Count; i++)
        {
            NotaList[i].Code = i;
        }

    }
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > MaxTimer)
        {
            Timer = 0;
            if (NotaActive)
            {
                Nota.SetActive(false);
                NotaActive = false;
            }

            else if (!NotaActive && NotaNumber < NotaList.Count)
            {
                Nota.SetActive(true);
                NotaActive = true;
            }
        }

        if(NotaNumber < NotaList.Count)
        {
            Guide.transform.position = this.transform.position;
            Guide.transform.LookAt(NotaList[NotaNumber].Point.transform);
        }
    }

    public void ChangeNumber(bool ChNu)
    {
        if (ChNu) {
            if(NotaNumber < NotaList.Count)
            {
                TMP_texto.text = NotaList[NotaNumber].Text;
                NotaActive = true;
                Nota.SetActive(true);
                Timer = 0;
            }
            else
            {
                //Termino de servir aqui se elimina todo
                NotaActive = false;
                Nota.SetActive(false);
                Destroy(this);
                Destroy(Guide);
            }
            ChNu = false;
        }
    }
}
[Serializable]
public class NotaText
{
    public int Code;
    [TextArea(3, 8)]
    public string Text;
    public GameObject Point;
}