using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerText : MonoBehaviour
{
    public GameObject text;
    public GameObject[] cubeant;

    private void Start()
    {
        text.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))

        {
            try
            {
                text.SetActive(true);
                Destroy(cubeant[0].gameObject);
                Destroy(cubeant[1].gameObject);
            }
            catch
            {

            }
        
        }
    }
}
