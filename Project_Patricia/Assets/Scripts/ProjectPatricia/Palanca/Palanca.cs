using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{
    [SerializeField] GameObject PalancaPivot;
    public PalancaState State;
    [SerializeField] bool Active = false;
    [SerializeField] float timeCount = 0.0f;
    //Cuanto tiempo demora
    [SerializeField] float timerOver = 2;
    public enum PalancaState
    {
        ON, Move, Off
    }
    void Update()
    {
        switch (State)
        {
            case PalancaState.ON:
                Active = true;
                timeCount = 0;
                break;
            case PalancaState.Move:
                if (!Active) {
                    PalancaPivot.transform.rotation = Quaternion.Lerp(Quaternion.Euler(-45f, 0f, 0f), Quaternion.Euler(45f, 0f, 0f), timeCount / timerOver);
                    timeCount = timeCount + Time.deltaTime;
                    if (timeCount >= timerOver)
                        State = PalancaState.ON;
                }
                else if (Active) {
                    PalancaPivot.transform.rotation = Quaternion.Lerp(Quaternion.Euler(45f, 0f, 0f), Quaternion.Euler(-45f, 0f, 0f), timeCount / timerOver);
                    timeCount = timeCount + Time.deltaTime;
                    if (timeCount >= timerOver)
                        State = PalancaState.Off;
                }
                break;
            case PalancaState.Off:
                Active = false;
                timeCount = 0;
                break;
        }
    }
}
