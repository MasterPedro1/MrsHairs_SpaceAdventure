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

    public GameObject Lightining;
   

    public void Disparar()
    {

        if (Physics.Raycast(rayCastOrigin.position, rayCastOrigin.transform.forward, out hit, rayCastMaxDistance))
        {
            if (hit.transform.tag == "Enemy")
            {
               // hit.transform.GetComponent<Enemy>().CambiarMaterialAleatorio();
                
            }
        }
        else isHitting = false;

        Debug.DrawRay(rayCastOrigin.position, rayCastOrigin.transform.forward * rayCastMaxDistance, Color.blue);

        Lightining.gameObject.SetActive(true);

        
    }

   public void StopShooting()
    {
        Lightining.gameObject.SetActive(false);
    }

}
