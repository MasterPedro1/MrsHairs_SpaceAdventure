using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Grabbable : MonoBehaviour
{
    private Rigidbody rbObj;
    Transform objectGrabPoint;
    [SerializeField] private float grabForce;
    [SerializeField]private float lerpSpeed = 1f;
    
    private void Awake()
    {
        rbObj= GetComponent<Rigidbody>();
        
    }
    public void Grab(Transform objectGrabPoint)
    {
        this.objectGrabPoint = objectGrabPoint;

        rbObj.useGravity = false;
        rbObj.isKinematic = true;
        rbObj.drag = grabForce;
        rbObj.interpolation = RigidbodyInterpolation.Extrapolate;
        

    }
    public void Drop()
    {
        this.objectGrabPoint = null;
        rbObj.useGravity = true;
        rbObj.isKinematic = false;
        rbObj.drag = 0;
    }
    private void Update()
    {
        if (objectGrabPoint != null)
        {
            this.transform.rotation = Quaternion.LookRotation(objectGrabPoint.forward, objectGrabPoint.up);

            Vector3 newPos = Vector3.Lerp(rbObj.position, objectGrabPoint.position, Time.deltaTime * lerpSpeed);
           // rbObj.MovePosition(newPos);
            transform.position = newPos;


        }

        
    }
    private void FixedUpdate()
    {
        
    }
}
