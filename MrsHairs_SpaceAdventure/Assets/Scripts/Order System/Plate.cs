using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public Dictionary<string, int> plateDishes = new Dictionary<string, int>();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DeliverStation"))
        {
            collision.gameObject.GetComponentInParent<DeliveryController>().SendPlateInfo(this);
        }
        if (collision.gameObject.CompareTag("Food"))
        {
            if (collision.gameObject.GetComponentInParent<Dish>().IsDishFinished)
            {
                PlaceDish(collision.gameObject.GetComponentInParent<Dish>().DishName);
                Debug.Log(plateDishes);
            }
        }
    }
    public void PlaceDish(string dish)
    {
        if(!plateDishes.ContainsKey(dish)) { plateDishes.Add(dish, 1); return; }
        plateDishes[dish]++;
    }
}
