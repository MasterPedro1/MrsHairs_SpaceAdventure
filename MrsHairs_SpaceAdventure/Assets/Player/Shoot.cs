using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private InteractWithObjects iwo;

    public GameObject balaPrefab; 
    public Transform puntoDisparo;

    void Update()
    {
        if (iwo.isAGun == true)
        {
            if (Input.GetKey("T"))
            {
                Disparar();
            }
        }
    }

    void Disparar()
    {
        
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);
        
        bala.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
    }
}
