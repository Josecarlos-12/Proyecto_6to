using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CansCount : MonoBehaviour
{
    [SerializeField] private CansTouch touch, touch2, touch3, touch4, touch5, touch6;
    [SerializeField] private int count;
    [SerializeField] private GameObject deer;

    private void Update()
    {
        Sum();
    }

    public void Sum()
    {
            count = touch.count + touch2.count + touch3.count + touch4.count + touch5.count + touch6.count;

        if(count >= 5 )
        {
            deer.SetActive(true);
        }
    }
}
