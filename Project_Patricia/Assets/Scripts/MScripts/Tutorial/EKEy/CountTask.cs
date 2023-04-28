using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CountTask : MonoBehaviour
{
    [SerializeField] NotesUI notes;
    public int one, two, three, four, five, six, seven, eight, nine;
    [SerializeField] int count, iTuto;
    [SerializeField] GameObject shift;
    [SerializeField] AnimTrue accept;
    [SerializeField] Animator animShift;
    [SerializeField] CountTask task;

    void Start()
    {
        
    }

    void Update()
    {
        if (notes.one)
        {
            if(one<3)
            one++;

            if (one==1)
            {
                count++;
            }            
        }
        if(notes.two)
        {
            if (two < 3)
                two++;

            if (two == 1)
            {
                count++;
            }
        }
        if (notes.three)
        {
            if (three < 3)
            three ++;

            if (three==1)
            {
                count++;
            }
        }
        if(notes.four)
        {
            if (four < 3)
                four++;

            if (four == 1)
            {
                count++;
            }
        }
        if (notes.five)
        {
            if (five < 3)
                five ++;

            if (five == 1)
            {
                count++;
            }
        }
        if(notes.six)
        {
            if (six < 3)
                six++;

            if (six == 1)
            {
                count++;
            }
        }
        if(notes.seven)
        {
            if (seven < 3)
                seven++;

            if (seven == 1)
            {
                count++;
            }
        }
        if(notes.eight)
        {
            if (eight < 3)
                eight++;

            if (eight == 1)
            {
                count++;
            }
        }
        if(notes.nine)
        {
            if (nine < 3)
                nine++;

            if (nine == 1)
            {
                count++;
            }
        }

        if (count < 4)
        {
            if (count > 1)
            {
                if (iTuto < 3)
                    iTuto++;

                if (iTuto == 1)
                {
                    shift.SetActive(true);
                }
            }
        }
        

        if (accept.finish && Input.GetKeyDown(KeyCode.LeftShift))
        {
            accept.finish = false;
            animShift.SetBool("Exit", true);
            StartCoroutine("OffPanel");
        }
    }

    public IEnumerator OffPanel()
    {
        yield return new WaitForSeconds(1.3f);
        shift.SetActive(false);
        task.enabled = false;
        Destroy(gameObject);
    }
}
