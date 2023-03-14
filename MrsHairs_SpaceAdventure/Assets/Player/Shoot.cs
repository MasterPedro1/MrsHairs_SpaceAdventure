using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [Header("Burbuja")]

    public GameObject balaPrefab; 
    public Transform puntoDisparo;
    public GameObject Boom;
    public float showRate = 5f;
    public float force;
    private float showRateTime;


    [Header("Rayo")]

    RaycastHit hit;
    [SerializeField] LayerMask enemies;
    public bool isAEnemy = false;
    [SerializeField] Transform rayCastOrigin;
    [SerializeField] float rayCastMaxDistance;


    void Update()
    {
        
    }

    public void Disparar()
    {
        //if (Time.time > showRateTime)
        //{
        //    GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);

        //    bala.GetComponent<Rigidbody>().AddForce(transform.forward * force);

        //    showRateTime = Time.time + showRate;

        //    Destroy(bala, 2);
        //}


        Physics.Raycast(rayCastOrigin.position, rayCastOrigin.transform.forward, out hit, rayCastMaxDistance, enemies);
        Debug.DrawRay(rayCastOrigin.position, rayCastOrigin.transform.forward, Color.blue);
        

    }
}
