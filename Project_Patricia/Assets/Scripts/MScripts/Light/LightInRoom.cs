using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInRoom : MonoBehaviour
{
    public GameObject[] up, down, on, lightFinish;
    public Floor1Switch[] switchFloor;
    public int upR, dowmR;
    [SerializeField] CatelynMove cat;
    public int[] upIndexes;
    public int[] downIndexes;

    [Header("Timer")]
    [SerializeField] private float time;
    [SerializeField] private float maxTime;

    public Enemy catEnemy;

    [Header("Final")]
    [SerializeField] private GameObject first, second;

    IEnumerator Start()
    {
        

        for (int i = 0; i < up.Length; i++)
        {
            up[i].SetActive(false);
        }

        for (int i = 0;i < down.Length; i++)
        {
            down[i].SetActive(false); 
        }

        for(int i = 0;i <switchFloor.Length; i++)
        {
            switchFloor[i].enabled= false;
        }
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < up.Length; i++)
        {
            up[i].SetActive(true);
        }

        for (int i = 0; i < down.Length; i++)
        {
            down[i].SetActive(true);
        }
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < up.Length; i++)
        {
            up[i].SetActive(false);
        }

        for (int i = 0; i < down.Length; i++)
        {
            down[i].SetActive(false);
        }
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < up.Length; i++)
        {
            up[i].SetActive(true);
        }

        for (int i = 0; i < down.Length; i++)
        {
            down[i].SetActive(true);
        }
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < up.Length; i++)
        {
            up[i].SetActive(false);
        }

        for (int i = 0; i < down.Length; i++)
        {
            down[i].SetActive(false);
        }
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < up.Length; i++)
        {
            up[i].SetActive(true);
        }

        for (int i = 0; i < down.Length; i++)
        {
            down[i].SetActive(true);
        }
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < up.Length; i++)
        {
            up[i].SetActive(false);
        }

        for (int i = 0; i < down.Length; i++)
        {
            down[i].SetActive(false);
        }
        StartCoroutine("NextLight");

        cat.catV2.SetActive(true);
        cat.container.SetActive(false);
        cat.catChangePos.transform.position = cat.transform.position;
    }

    private void Update()
    {
        time += Time.deltaTime;

        if(time>maxTime)
        {
            //StopCoroutine("NextLight");            

            /*for (int i = 0; i < up.Length; i++)
            {
                up[i].SetActive(false);
            }

            for (int i = 0; i < down.Length; i++)
            {
                down[i].SetActive(false);
            }
            catEnemy.state = Enemy.State.follow;*/
            first.gameObject.SetActive(true);
            //second.gameObject.SetActive(true);

            this.gameObject.SetActive(false);
        }
    }

    /*public IEnumerator NextLight()
    {
        yield return new WaitForSeconds(0);
        upR = Random.Range(0, up.Length);
        up[upR].SetActive(true);
        Debug.Log("Prendio: " + up);

        dowmR = Random.Range(0, dowm.Length);
        dowm[dowmR].SetActive(true);

        yield return new WaitForSeconds(10);
        up[upR].SetActive(false);

        dowm[dowmR].SetActive(false);
        yield return NextLight();
    }*/


    public IEnumerator NextLight()
    {
        // Encender 4 objetos aleatorios de la matriz "up"
        upIndexes = GenerateRandomIndexes(up.Length, 2);
        foreach (int index in upIndexes)
        {
            up[index].SetActive(true);
        }

        // Encender 4 objetos aleatorios de la matriz "down"
        downIndexes = GenerateRandomIndexes(down.Length, 2);
        foreach (int index in downIndexes)
        {
            down[index].SetActive(true);
        }

        yield return new WaitForSeconds(15);

        // Apagar los objetos encendidos de la matriz "up"
        foreach (int index in upIndexes)
        {
            up[index].SetActive(false);
        }

        // Apagar los objetos encendidos de la matriz "down"
        foreach (int index in downIndexes)
        {
            down[index].SetActive(false);
        }

        yield return NextLight();
    }

    private int[] GenerateRandomIndexes(int length, int count)
    {
        List<int> indexes = new List<int>();
        for (int i = 0; i < length; i++)
        {
            indexes.Add(i);
        }

        indexes = ShuffleList(indexes);

        int[] randomIndexes = new int[count];
        for (int i = 0; i < count; i++)
        {
            randomIndexes[i] = indexes[i];
        }

        return randomIndexes;
    }

    private List<T> ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
        return list;
    }

}
