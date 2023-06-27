using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTutorial : MonoBehaviour
{
    [SerializeField] private TasksUI task;
    [SerializeField] private GameObject panelTuto;
    [SerializeField] private Animator anim;
    [SerializeField] private int on;
    [SerializeField] AnimTrue animPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && animPanel.finish || Input.GetKeyDown(KeyCode.A) && animPanel.finish || Input.GetKeyDown(KeyCode.S) && animPanel.finish || Input.GetKeyDown(KeyCode.D) && animPanel.finish)
        {            
            anim.SetBool("Exit", true);
            

            if(on<3)
            on++;

            if(on==1)
            {
                StartCoroutine("PanelOff");
            }
        }
    }


    public IEnumerator PanelOff()
    {
        yield return new WaitForSeconds(1.35f);
        panelTuto.SetActive(false);
    }
}
