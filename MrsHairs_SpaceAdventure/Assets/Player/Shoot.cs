using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

   

    [Header("Rayo")]

    public RaycastHit hit;
    [SerializeField] Transform rayCastOrigin;
    [SerializeField] float rayCastMaxDistance;
    public Enemy enemy;


    void Update()
    {
        
    }

    public void Disparar()
    {
        Physics.Raycast(rayCastOrigin.position, rayCastOrigin.transform.forward, out hit, rayCastMaxDistance);

       //if (Physics.Raycast(rayCastOrigin.position, rayCastOrigin.transform.forward, out hit, rayCastMaxDistance))
       // {
       //     if (hit.collider.CompareTag("Enemy"))
       //     {
       //         enemy.ischocking = false;
       //         enemy = hit.transform.GetComponent<Enemy>();
       //     }

       //     else
       //         enemy.ischocking = false;
       // }
       
        Debug.DrawRay(rayCastOrigin.position, rayCastOrigin.transform.forward * rayCastMaxDistance, Color.blue);
    }
}
