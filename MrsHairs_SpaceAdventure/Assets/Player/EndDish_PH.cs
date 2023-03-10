using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDish_PH : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DeliverStation") other.GetComponent<OrderTimer_PH>().onDeliver.Invoke();
    }
}
