using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CamaraRotate : MonoBehaviour
{
    public GameObject camara_Pivot;
    public GameObject Player;
    public float speed;
    public State state;
    public TMP_Text TextM;

    public enum State 
    {
        Norte,NorEste,Este,SurEste,Sur,SurOeste,Oeste,NorOeste
    }

    void Start()
    {
        Detect();
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            camara_Pivot.transform.Rotate(new Vector3(0, camara_Pivot.transform.rotation.y - speed, 0) * Time.deltaTime);
            Detect();
        }
        else if (Input.GetKey(KeyCode.E))
        {
            camara_Pivot.transform.Rotate(new Vector3(0, camara_Pivot.transform.rotation.y + speed, 0) * Time.deltaTime);
            Detect();
        }
        this.gameObject.transform.position = Player.transform.position;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            ModifyRotation();
        }
       //Debug.Log(transform.rotation.eulerAngles.y);
    }

    void Detect()
    {
        TextM.text = state.ToString();

        var v = transform.forward;
        v.y = 0;
        v.Normalize();

        if (Vector3.Angle(v, Vector3.forward) <= 22.5)
        {
            state = State.Norte;
        }
        else if (Vector3.Angle(v, Vector3.right + Vector3.forward) <= 22.5)
        {
            state = State.NorEste;
        }
        else if (Vector3.Angle(v, Vector3.right) <= 22.5)
        {
            state = State.Este;
        }
        else if (Vector3.Angle(v, Vector3.right + Vector3.back) <= 22.5)
        {
            state = State.SurEste;
        }
        else if (Vector3.Angle(v, Vector3.back) <= 22.5)
        {
            state = State.Sur;
        }
        else if (Vector3.Angle(v, Vector3.back + Vector3.left) <= 22.5)
        {
            state = State.SurOeste;
        }
        else if (Vector3.Angle(v, Vector3.left) <= 22.5)
        {
            state = State.Oeste;
        }
        else if (Vector3.Angle(v, Vector3.forward + Vector3.left) <= 22.5)
        {
            state = State.NorOeste;
        }
    }

    void ModifyRotation()
    {
        if (state == State.Norte)
        {
            transform.rotation = Quaternion.Euler(0f, 0, 0f);
        }
        else if (state == State.NorEste)
        {
            transform.rotation = Quaternion.Euler(0f, 45, 0f);
        }
        else if (state == State.Este)
        {
            transform.rotation = Quaternion.Euler(0f, 90, 0f);
        }
        else if (state == State.SurEste)
        {
            transform.rotation = Quaternion.Euler(0f, 135, 0f);
        }
        else if (state == State.Sur)
        {
            transform.rotation = Quaternion.Euler(0f, 180, 0f);
        }
        else if (state == State.SurOeste)
        {
            transform.rotation = Quaternion.Euler(0f, -135, 0f);
        }
        else if (state == State.Oeste)
        {
            transform.rotation = Quaternion.Euler(0f, -90, 0f);
        }
        else if (state == State.NorOeste)
        {
            transform.rotation = Quaternion.Euler(0f, -45, 0f);
        }
        Detect();
    }

}
