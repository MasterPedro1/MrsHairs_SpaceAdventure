using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fry : MonoBehaviour
{
    [SerializeField] GameObject cookingBounds;
    Transform foodT;
    bool isCooking = false;

    private void Update()
    {
            
    }


    private void OnTriggerEnter(Collider other)
    {       
        if (other.CompareTag("Food"))
        {            
           // other.gameObject.transform.SetParent(this.transform, true);   
            cookingBounds.SetActive(true);
            foodT = other.transform;
            isCooking = true;
            StartCoroutine(Cooking(15f));
        }
    }


    private IEnumerator Cooking(float time)
    {
            //foodT.position = cookingBounds.transform.position;
            yield return new WaitForSeconds(time);
            cookingBounds.SetActive(false);
            isCooking = false;
        
    }
}
