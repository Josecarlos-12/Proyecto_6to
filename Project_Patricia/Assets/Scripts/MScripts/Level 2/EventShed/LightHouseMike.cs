using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHouseMike : MonoBehaviour
{
    [SerializeField] private KeyGrabShed key;
    [SerializeField] private int count;
    [SerializeField] private Animator[] lightHouse;

    [Header("Lights House")]
    [SerializeField] private Animator[] lightOne;
    [SerializeField] private Animator[] lightTwo;
    [SerializeField] private Animator[] lightThree;
    [SerializeField] private Animator[] lightFour;
    [SerializeField] private Animator[] lightFive;
    [SerializeField] private Animator[] lightSix;
    [SerializeField] private Animator[] lightSeven;


    void Update()
    {
        if (key.onLight)
        {
            if(count<3)
            count++;

            if(count == 1)
            {
                for (int i = 0; i < lightHouse.Length; i++)
                {
                    lightHouse[i].SetBool("Off", true);
                }
                StartCoroutine("CorutineStart");
            }
        }
    }

    public IEnumerator CorutineStart()
    {
        yield return new WaitForSeconds(2);
        LightOneOn();
        yield return new WaitForSeconds(8);
        LightOneOff();
        yield return new WaitForSeconds(2);
        LightTwoOn();
        yield return new WaitForSeconds(8);
        LightTwoOff();
        yield return new WaitForSeconds(2);
        LightThreeOn();
        yield return new WaitForSeconds(8);
        LightThreeOff();
        yield return new WaitForSeconds(2);
        LightFourOn();
        yield return new WaitForSeconds(8);
        LightFourOff();
        yield return new WaitForSeconds(2);
        LightThreeOn();
        yield return new WaitForSeconds(8);
        LightThreeOff();
        yield return new WaitForSeconds(2);
        LightFourOn();
        yield return new WaitForSeconds(8);
        LightFourOff();
        yield return new WaitForSeconds(2);
        LightFiveOn();
        yield return new WaitForSeconds(8);
        LightFiveOff();
        yield return new WaitForSeconds(2);
        LightThreeOn();
        yield return new WaitForSeconds(8);
        LightThreeOff();
        yield return new WaitForSeconds(2);
        LightFiveOn();
        yield return new WaitForSeconds(8);
        LightFiveOff();
        yield return new WaitForSeconds(2);
        LightSixOn();
        yield return new WaitForSeconds(8);
        LightSixOff();
        yield return new WaitForSeconds(2);
        LightSevenOn();
        // De Reversa
        yield return new WaitForSeconds(8);
        LightSevenOff();
        yield return new WaitForSeconds(2);
        LightSixOn();
        yield return new WaitForSeconds(8);
        LightSixOff();
        yield return new WaitForSeconds(2);
        LightFiveOn();
        yield return new WaitForSeconds(8);
        LightFiveOff();
        yield return new WaitForSeconds(2);
        LightThreeOn();
        yield return new WaitForSeconds(8);
        LightThreeOff();
        yield return new WaitForSeconds(2);
        LightFiveOn();
        yield return new WaitForSeconds(8);
        LightFiveOff();
        yield return new WaitForSeconds(2);
        LightFourOn();
        yield return new WaitForSeconds(8);
        LightFourOff();
        yield return new WaitForSeconds(2);
        LightThreeOn();
        yield return new WaitForSeconds(8);
        LightThreeOff();
        yield return new WaitForSeconds(2);
        LightFourOn();
        yield return new WaitForSeconds(8);
        LightFourOff();
        yield return new WaitForSeconds(2);
        LightThreeOn();
        yield return new WaitForSeconds(8);
        LightThreeOff();
        yield return new WaitForSeconds(2);
        LightTwoOn();
        yield return new WaitForSeconds(8);
        LightTwoOff();
        yield return CorutineStart();
    }

    #region LightOne
    public void LightOneOn()
    {
        for (int i = 0; i < lightOne.Length; i++)
        {
            lightOne[i].SetBool("Off", false);
        }
    }

    public void LightOneOff()
    {
        for (int i = 0; i < lightOne.Length; i++)
        {
            lightOne[i].SetBool("Off", true);
        }
    }
    #endregion

    #region LightTwo
    public void LightTwoOn()
    {
        for (int i = 0; i < lightTwo.Length; i++)
        {
            lightTwo[i].SetBool("Off", false);
        }
    }

    public void LightTwoOff()
    {
        for (int i = 0; i < lightTwo.Length; i++)
        {
            lightTwo[i].SetBool("Off", true);
        }
    }
    #endregion

    #region LightThree
    public void LightThreeOn()
    {
        for (int i = 0; i < lightThree.Length; i++)
        {
            lightThree[i].SetBool("Off", false);
        }
    }

    public void LightThreeOff()
    {
        for (int i = 0; i < lightThree.Length; i++)
        {
            lightThree[i].SetBool("Off", true);
        }
    }
    #endregion

    #region LightFour
    public void LightFourOn()
    {
        for (int i = 0; i < lightFour.Length; i++)
        {
            lightFour[i].SetBool("Off", false);
        }
    }

    public void LightFourOff()
    {
        for (int i = 0; i < lightFour.Length; i++)
        {
            lightFour[i].SetBool("Off", true);
        }
    }
    #endregion

    #region LightFive
    public void LightFiveOn()
    {
        for (int i = 0; i < lightFive.Length; i++)
        {
            lightFive[i].SetBool("Off", false);
        }
    }

    public void LightFiveOff()
    {
        for (int i = 0; i < lightFive.Length; i++)
        {
            lightFive[i].SetBool("Off", true);
        }
    }
    #endregion

    #region LightSix
    public void LightSixOn()
    {
        for (int i = 0; i < lightSix.Length; i++)
        {
            lightSix[i].SetBool("Off", false);
        }
    }

    public void LightSixOff()
    {
        for (int i = 0; i < lightSix.Length; i++)
        {
            lightSix[i].SetBool("Off", true);
        }
    }
    #endregion

    #region LightSeven
    public void LightSevenOn()
    {
        for (int i = 0; i < lightSeven.Length; i++)
        {
            lightSeven[i].SetBool("Off", false);
        }
    }

    public void LightSevenOff()
    {
        for (int i = 0; i < lightSeven.Length; i++)
        {
            lightSeven[i].SetBool("Off", true);
        }
    }
    #endregion
}
