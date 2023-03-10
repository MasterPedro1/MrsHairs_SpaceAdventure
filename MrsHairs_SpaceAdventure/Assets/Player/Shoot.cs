using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    

    public GameObject balaPrefab; 
    public Transform puntoDisparo;
    public GameObject Boom;
    public float showRate = 5f;
    public float force;

    private float showRateTime;

    void Update()
    {
        
    }

    public void Disparar()
    {
            

        if (Time.time > showRateTime)
        {
            GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);

            bala.GetComponent<Rigidbody>().AddForce(transform.forward * force);

            showRateTime = Time.time + showRate;

            Destroy(bala, 2);
        }

        
            
    }
}
