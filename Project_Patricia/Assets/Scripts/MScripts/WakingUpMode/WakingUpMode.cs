using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class WakingUpMode : MonoBehaviour
{
    [Header("Volume")]
    public Volume volume;
    public WhiteBalance balance;
    public Fog fog;
    

    void Start()
    {
        volume.profile.TryGet(out WhiteBalance VBalance);
        balance = VBalance;


        volume.profile.TryGet(out Fog VFog);
        fog = VFog;
    }   

    public void WakingOn()
    {
        fog.active= true;
        balance.active = true;
        balance.temperature.value = -51;
    }

    public void WakingOff()
    {
        fog.active = false;
        balance.active = false;
        balance.temperature.value = 0;
    }
}
