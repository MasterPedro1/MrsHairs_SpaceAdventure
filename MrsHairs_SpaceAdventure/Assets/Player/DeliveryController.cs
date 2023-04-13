using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryController : MonoBehaviour
{
    public OrderManager _orderManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            Dish dishToCheck = collision.gameObject.GetComponent<Dish>();
            if (dishToCheck.IsDishFinished)
            {
                _orderManager.CheckDelivery(dishToCheck);
            }
        }
    }
}
