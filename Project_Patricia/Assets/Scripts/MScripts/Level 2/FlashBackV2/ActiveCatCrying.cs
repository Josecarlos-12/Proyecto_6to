using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCatCrying : MonoBehaviour
{
    [SerializeField] private GameObject cat;
    public enum State
    {
        active, desactive 
    }
    public State state;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (state)
            {
                case State.active:
                    Destroy(gameObject);
                    cat.SetActive(true);
                    break;
                    case State.desactive:
                    Destroy(gameObject);
                    cat.SetActive(false);
                    break;
            }

            
        }
    }
}
