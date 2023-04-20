using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyRot : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject[] points, points2, groupEnemys;
    [SerializeField] bool go, groupEnemy, change;
    [SerializeField] float time, maxTime;
    [SerializeField] List<GameObject> tags;
    [SerializeField] int count;

    private void Start()
    {
        StartCoroutine("ChangeEnemys");
    }

    private void Update()
    {
        if (go)
        {
            if (change)
            {
                if (groupEnemy)
                {
                    if(count<3)
                    count++;

                    if(count==1)
                    {
                        for (int i = 0; i < points.Length; i++)
                        {
                            GameObject ene = Instantiate(enemy, points[i].transform.position, points[i].transform.rotation);
                            ene.SetActive(true);
                        }
                    }

                    
                }
                else
                {
                    if (count < 3)
                        count++;

                    if (count == 1)
                    {
                        for (int i = 0; i < points2.Length; i++)
                        {
                            GameObject ene = Instantiate(enemy, points2[i].transform.position, points2[i].transform.rotation);
                            ene.SetActive(true);
                        }
                    }                   
                }
            }                
                 
        }
    }


    public IEnumerator ChangeEnemys()
    {

        yield return new WaitForSeconds(30);
        count = 0;
        change= false;
        groupEnemys = GameObject.FindGameObjectsWithTag("EnemyRot");
        tags.AddRange(groupEnemys);

        foreach (GameObject item in tags)
        {
            Destroy(item);
           
        }
        yield return new WaitForSeconds(1);
        tags.Clear();
        change= true;
        groupEnemy = !groupEnemy;
        yield return ChangeEnemys();
    }

}
