using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloseCatSotano : MonoBehaviour
{
    [SerializeField] private GameObject textE, spotLight;
    [SerializeField] private bool into;
    [SerializeField] private AudioSource audioDoor;
    [SerializeField] private Collider col;
    [SerializeField] private Animator animChart;

    [Header("Chart")]
    [SerializeField] private GameObject chart;
    [SerializeField] private GameObject aim;
    [SerializeField] private GameObject camChart, prota;

    [SerializeField] private TasksUILevel2 task;

    public enum Change
    {
        door, chart
    }
    public Change change;

    private void Update()
    {
        if(into && Input.GetKeyDown(KeyCode.E))
        {
            switch (change)
            {
                case Change.door:
                    task.taskCount = 2;
                    Desactive();
                    spotLight.SetActive(false);
                    StartCoroutine("ChartShiny");
                    print("Puerta Cerrada");
                    break; 
                case Change.chart:
                    aim.SetActive(false);
                    Desactive();
                    chart.SetActive(false);
                    prota.SetActive(false);
                    camChart.SetActive(true);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    print("Cuadro");
                    break;
            }
        }
    }

    public void Desactive()
    {
        col.enabled = false;
        into = false;
        textE.SetActive(false);
    }

    public IEnumerator ChartShiny()
    {
        yield return new WaitForSeconds(0.5f);
        animChart.SetBool("On", true);
        chart.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into= true;
            textE.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = false;
            textE.SetActive(false);
        }
    }
}
