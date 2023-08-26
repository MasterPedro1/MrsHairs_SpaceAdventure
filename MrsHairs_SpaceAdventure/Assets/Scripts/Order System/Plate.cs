using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public Dictionary<string, int> plateDishes = new Dictionary<string, int>();
    public Transform dishAnchors;

    private int _anchorIndx = 0;
    private List<Transform> _anchor = new List<Transform>();
    private List<GameObject> _dishMesh = new List<GameObject>();
    private ObjDispenser _dispenser;

    private void Awake()
    {
        foreach (Transform plateAnchor in dishAnchors.GetComponentInChildren<Transform>())
        {
            _anchor.Add(plateAnchor);
        }
        _dispenser = FindObjectOfType<ObjDispenser>();
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
                //Destroy(collision.gameObject);
                collision.gameObject.SetActive(false);
                collision.gameObject.GetComponent<Dish>().ResetDishData();
            }
        }
    }
    public void ReturnPlate()
    {
        foreach(GameObject mesh in  _dishMesh)
        {
            Destroy(mesh);
        }
        _anchorIndx = 0;
        plateDishes.Clear();
        _dispenser.ResetObjPosition(transform);
    }
    public void PlaceDish(string dish, GameObject finishedDish)
    {
        GameObject foodMesh = Instantiate(finishedDish, _anchor[_anchorIndx].position, _anchor[_anchorIndx].rotation, _anchor[_anchorIndx]);
        foodMesh.SetActive(true);
        _dishMesh.Add(foodMesh);
        _anchorIndx++;
        if (!plateDishes.ContainsKey(dish))
        {
            plateDishes.Add(dish, 1);
            return;
        }
        plateDishes[dish]++;
    }
}
