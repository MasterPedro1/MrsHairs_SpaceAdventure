using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrival : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
 
   

    private void Start()
    {
        
        
    }

    void Update()
    {
        
            Vector3 dir = target.position - transform.position;
            dir.y = 0; // Optional: Make the object only move in the XZ plane
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.1f);

            transform.Translate(0, 0, speed * Time.deltaTime);
        
    }

    IEnumerator WaitToSpawn()
    {
        yield return new WaitForSeconds(3);
    }
}
