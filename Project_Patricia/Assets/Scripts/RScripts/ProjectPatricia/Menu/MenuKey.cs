using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuKey : MonoBehaviour
{
    //[Header("Habilidades")]
    //public Jump jump;
    //public Shield shield;
    //public DashController dash;
    //public Sword sword;


    [SerializeField] GameObject Button;
    public TMP_Text ButtonText;
    //public Movement PlayerMov;
    public KeyCode NewKey;
    public State state;


    public float Timer = 0;
    public bool Active = false;

    protected List<KeyCode> m_activeInputs = new List<KeyCode>();

    public enum State
    {
        adelante, atras, izquierda, derecha
    }
    void Start()
    {
        switches();
    }
    void Update()
    {
        if (Active)
        {
            if (Input.anyKeyDown)
            {
                Codes();
                NewKey = m_activeInputs[0];
                switches();
                Button.SetActive(true);
                Active = false;
            }
            Codes();
        }
        else
        ButtonText.text = NewKey.ToString();

    }

    void switches()
    {
        //if (Active)
        //{
        //    switch (state)
        //    {
        //        case State.adelante:
        //            //Delante
        //            //PlayerMov.adelante = NewKey;
        //            jump.kJP = NewKey;
        //            break;
        //        case State.atras:
        //            //Atras
        //            shield.kSh = NewKey;
        //            break;
        //        case State.izquierda:
        //            //Izquierda
        //            dash.kDash = NewKey;
        //            break;
        //        case State.derecha:
        //            //Derecha
        //            sword.kSworrd = NewKey;
        //            break;
        //    }
        //}
        //else
        //{
        //    switch (state)
        //    {
        //        case State.adelante:
        //            //NewKey = PlayerMov.adelante;
        //            NewKey = jump.kJP;
        //            break;
        //        case State.atras:
        //            //NewKey = PlayerMov.atras;
        //            NewKey = shield.kSh;
        //            break;
        //        case State.izquierda:
        //            //NewKey = PlayerMov.izquierda;
        //            NewKey = dash.kDash;
        //            break;
        //        case State.derecha:
        //            //NewKey = PlayerMov.derecha;
        //            NewKey = sword.kSworrd;
        //            break;
        //    }
        //}
    }
    public void ChangeInput()
    {
        Button.SetActive(false);
        Active = true;
    }
    public void Codes()
    {
        List<KeyCode> pressedInput = new List<KeyCode>();

        if (Input.anyKeyDown || Input.anyKey)
        {
            foreach (KeyCode code in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(code))
                {
                    m_activeInputs.Remove(code);
                    m_activeInputs.Add(code);
                    pressedInput.Add(code);

                    //Debug.Log(code + " was pressed");
                }
            }
        }

        List<KeyCode> releasedInput = new List<KeyCode>();

        foreach (KeyCode code in m_activeInputs)
        {
            releasedInput.Add(code);

            if (!pressedInput.Contains(code))
            {
                releasedInput.Remove(code);

                //Debug.Log(code + " was released");
            }
        }
        m_activeInputs = releasedInput;


    }
}

