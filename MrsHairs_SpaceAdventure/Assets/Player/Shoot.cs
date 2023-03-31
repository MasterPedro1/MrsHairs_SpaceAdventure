using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Rayo")]

    public RaycastHit hit;
    public bool isHitting = false;
    [SerializeField] Transform rayCastOrigin;
    [SerializeField] float rayCastMaxDistance;
    [SerializeField] LayerMask enemyLayer;

    public GameObject lightining;
   

    public void Disparar()
    {

        if (Physics.Raycast(rayCastOrigin.position, rayCastOrigin.transform.forward, out hit, rayCastMaxDistance))
        {
            if(hit.transform.tag == "Enemy")
            isHitting = true;

        }
        else isHitting = false;

        Debug.DrawRay(rayCastOrigin.position, rayCastOrigin.transform.forward * rayCastMaxDistance, Color.blue);

        lightining.gameObject.SetActive(true);

        
    }

   

}
