using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractWithObjects : MonoBehaviour
{
    public InputActionProperty pinchAction;

    [SerializeField] Transform rayCastOrigin, objectGrabPoint;
    [SerializeField] float rayCastMaxDistance;
    [SerializeField] LayerMask propsLayer;
    bool isAProp = false;
    Grabbable objectGrabbable;

    private void Update()
    {
        float triggerValue = pinchAction.action.ReadValue<float>();
        //Debug.Log(triggerValue);
        
        if (Input.GetMouseButton(0))
        {
            TryGrab();
        }
        else if (triggerValue <= 0 && objectGrabbable != null)
        {
            objectGrabbable.Drop();
            objectGrabbable= null;
        }
     
    }
    private void TryGrab()
    {
        RaycastHit hit;
        isAProp = Physics.Raycast(rayCastOrigin.position, rayCastOrigin.transform.forward, out hit, rayCastMaxDistance, propsLayer);
        Debug.DrawRay(rayCastOrigin.position, rayCastOrigin.transform.forward, Color.green);
       //if (hit.collider != null) Debug.Log("Agarraste " + hit.collider.name);
        if (objectGrabbable == null)
        {
            if (isAProp && hit.transform.TryGetComponent(out objectGrabbable))
            {
                objectGrabbable.Grab(objectGrabPoint);
                //Debug.Log(hit.transform);
            }
        }
        //if (hit.collider !=  null) Debug.Log(hit.transform);
    }
}
