using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public Dictionary<string, int> dishOnPlate = new Dictionary<string, int>();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DeliverStation")) { collision.gameObject.GetComponentInParent<OrderManager>().CheckDelivery(this); }
    }

    public void PlaceDish(string dish)
    {
        if(!dishOnPlate.ContainsKey(dish)) { dishOnPlate.Add(dish, 1); return; }
        dishOnPlate[dish]++;
    }
}
