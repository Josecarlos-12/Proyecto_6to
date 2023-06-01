using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FusesCount : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject dialogue, cat;
    [SerializeField] private Fuses[] fuses;
    [SerializeField] private int one, two, three, four, five, six;
    [SerializeField] private int oneC, twoC, threeC, fourC, fiveC, sixC;
    [SerializeField] private AudioSource mike;
    [SerializeField] private AudioClip clip;

    private void Update()
    {
        if (fuses[0].touch)
        {
            if(one<3)
            one++;

            if (one == 1)
            {
                oneC++;
            }
        }
        if (fuses[1].touch)
        {
            if (two < 3)
                two++;

            if (two == 1)
            {
                oneC++;
            }
        }
        if (fuses[2].touch)
        {
            if (three < 3)
                three++;

            if (three == 1)
            {
                oneC++;
            }
        }
        if (fuses[3].touch)
        {
            if (four < 3)
                four++;

            if (four == 1)
            {
                oneC++;
            }
        }
        if (fuses[4].touch)
        {
            if (five < 3)
                five++;

            if (five == 1)
            {
                oneC++;
            }
        }
        if (fuses[5].touch)
        {
            if (six < 3)
                six++;

            if (six == 1)
            {
                oneC++;
            }
        }

        if (oneC >= 2)
        {
            if(twoC< 3)
            twoC++;

            if (twoC == 1)
            {
                StartCoroutine("Dialogue");
            }
        }
    }

    public IEnumerator Dialogue()
    {
        mike.clip = clip;
        mike.Play();

        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Mike Schmith: Parece que nada de esto va a funcionar";
        yield return new WaitForSeconds(3);
        dialogue.SetActive(false);
        yield return new WaitForSeconds(1);
        cat.SetActive(true);
        dialogue.SetActive(true);
        dialogue.GetComponent<TextMeshProUGUI>().text = "Catelyn Schmith: Mike, ¿Por qué Charlie no está en su habitación?";
        yield return new WaitForSeconds(4);
        dialogue.SetActive(false);
        anim.SetBool("Punch", true);
        print("Lapazo");
    }
}
