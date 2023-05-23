using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public Dictionary<string, int> plateDishes = new Dictionary<string, int>();
    public Transform dishAnchors;

    private int anchorIndx = 0;
    private List<Transform> anchor = new List<Transform>();

    private void Awake()
    {
        foreach (Transform plateAnchor in dishAnchors.GetComponentInChildren<Transform>())
        {
            anchor.Add(plateAnchor);
        }
    }
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
                PlaceDish(collision.gameObject.GetComponentInParent<Dish>().DishName, collision.gameObject.GetComponentInParent<Dish>().finishedDish);
                Destroy(collision.gameObject);
            }
        }
    }
    public void PlaceDish(string dish, GameObject finishedDish)
    {
        GameObject foodMesh = Instantiate(finishedDish, anchor[anchorIndx].position, anchor[anchorIndx].rotation, anchor[anchorIndx]);
        foodMesh.SetActive(true);
        anchorIndx++;
        if (!plateDishes.ContainsKey(dish))
        {
            plateDishes.Add(dish, 1);
            return;
        }
        plateDishes[dish]++;
    }
}
