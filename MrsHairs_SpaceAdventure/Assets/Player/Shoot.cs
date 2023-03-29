using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Rayo")]

    public RaycastHit hit;

    [SerializeField] Transform rayCastOrigin;
    [SerializeField] float rayCastMaxDistance;
    [SerializeField] LayerMask enemyLayer;

    public GameObject lightining;
   
    

    public void Disparar()
    {
        if(Physics.Raycast(rayCastOrigin.position, rayCastOrigin.transform.forward, out hit, rayCastMaxDistance, enemyLayer))
        {
          
               hit.transform.GetComponent<Enemy>().QuitarVida();
        }

        Debug.DrawRay(rayCastOrigin.position, rayCastOrigin.transform.forward * rayCastMaxDistance, Color.blue);

        lightining.gameObject.SetActive(true);

        
    }

   

}
