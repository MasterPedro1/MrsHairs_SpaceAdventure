using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    

    public GameObject balaPrefab; 
    public Transform puntoDisparo;

    void Update()
    {
        
    }

    public void Disparar()
    {

        
        
            GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);

            bala.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
        
    }
}
