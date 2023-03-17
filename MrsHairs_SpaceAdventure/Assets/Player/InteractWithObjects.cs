using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class InteractWithObjects : MonoBehaviour
{
    public InputActionProperty pinchAction;

    [SerializeField] Transform rayCastOrigin, objectGrabPoint;
    [SerializeField] float rayCastMaxDistance;
    [SerializeField] LayerMask propsLayer;
    [SerializeField] LayerMask gunsLayer;
    private Shoot sh;

    bool isAProp = false;
    public bool isAGun = false;

    RaycastHit hit;
    Grabbable objectGrabbable;
    AdvancedInteractions advancedInteractions;

    private void Update()
    {
        float triggerValue = pinchAction.action.ReadValue<float>();
        //Debug.Log(triggerValue);
        
        if (Input.GetMouseButton(0))
        {
            if (IsAProp())
            {
                Interact();
            }         

            if(IsGun())
            {
                isAGun = true;
                Interact();
            }

            else
                isAGun = false;
        }
        else if (objectGrabbable != null)
        {
            objectGrabbable.Drop();
            objectGrabbable= null;
        }

        if (Input.GetMouseButton(1) && objectGrabbable != null)
        {
            sh = objectGrabbable.gameObject.GetComponent<Shoot>();
            
            //Debug.Log("Esta Disparando");
            sh.Disparar();
        }
      
     
    }
    private void Interact()
    {       
       //if (hit.collider != null) Debug.Log("Agarraste " + hit.collider.name);
        if (objectGrabbable == null)
        {
            if (hit.transform.TryGetComponent(out objectGrabbable))
            {
                objectGrabbable.Grab(objectGrabPoint);
                //Debug.Log(hit.transform);
            }
            else if (hit.transform.TryGetComponent(out advancedInteractions))
            {
                advancedInteractions.InvokeAdvancedInteraction();
            }

           
               
        }


        //if (hit.collider !=  null) Debug.Log(hit.transform);
    }

    private bool IsAProp()
    {        
        isAProp = Physics.Raycast(rayCastOrigin.position, rayCastOrigin.transform.forward, out hit, rayCastMaxDistance, propsLayer);
        Debug.DrawRay(rayCastOrigin.position, rayCastOrigin.transform.forward, Color.green);
        return isAProp;
    }

    private bool IsGun()
    {
        
        isAGun = Physics.Raycast(rayCastOrigin.position, rayCastOrigin.transform.forward, out hit, rayCastMaxDistance, gunsLayer);
        Debug.DrawRay(rayCastOrigin.position, rayCastOrigin.transform.forward, Color.green);
        return isAGun;
    }
}
