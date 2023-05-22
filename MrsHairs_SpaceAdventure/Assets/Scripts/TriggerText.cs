using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerText : MonoBehaviour
{
    public GameObject text;
    public GameObject cubeant;

    private void Start()
    {
        text.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))

        { 
            text.SetActive(true);
            Destroy(cubeant.gameObject);
        
        }
    }
}
