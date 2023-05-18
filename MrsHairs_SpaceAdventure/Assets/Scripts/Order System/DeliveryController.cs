using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryController : MonoBehaviour
{
    public OrderManager orderManager;
    public WorldOrder orderToCheck;

    public void SendPlateInfo(Plate plateToCheck)
    {
        orderManager.CheckDelivery(orderToCheck, plateToCheck);
    }
}
