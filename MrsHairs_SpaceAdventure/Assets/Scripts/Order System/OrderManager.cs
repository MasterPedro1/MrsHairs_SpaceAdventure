using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Profiling;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.Rendering.DebugUI;

public class OrderManager : MonoBehaviour
{
    [Header("Manager variables")]
    public bool createOrders = true;
    public List<WorldOrder> visualOrders = new List<WorldOrder>();

    [Space(2.5f), Header("Orders to appear")]
    public int orderListLimit = 5;
    public float orderAdditionTimer = 7.5f;
    public List<Order> activeOrders = new List<Order>();

    [Space(2.5f), Header("Order details")]
    public float ordersTimeLimit = 30;
    public int minDishQuantity = 2, maxDishQuantity = 4;
    public List<Dish> possibleDishes = new List<Dish>();

    private List<int> closedOrderIndx = new List<int>();

    private void Awake()
    {
        VisualOrderOrganizer();
    }
    private void Start()
    {
        CreateOrder();
        CreateOrder();
        StartCoroutine(PlaceOrder());
        StartCoroutine(OrderTimer());
    }
    public void CheckDelivery(Plate orderDelivered)
    {
        bool orderCoincidence = false;
        foreach(Order orderToCheck in activeOrders)
        {
            Debug.Log(orderToCheck.OrderDish.Equals(orderDelivered.plateDishes));
            /*
            foreach (string key in orderDelivered.plateDishes.Keys)
            {
                if (!orderToCheck.OrderDish.ContainsKey(key)) { break; }
                if (orderDelivered.plateDishes[key] != orderToCheck.OrderDish[key]) { break; }

            }*/
        }
    }
    IEnumerator PlaceOrder()
    {
        yield return new WaitForSeconds(orderAdditionTimer);

        if (createOrders && activeOrders.Count < orderListLimit)
        {
            CreateOrder();
        }
        StartCoroutine(PlaceOrder());
    }
    private void CreateOrder()
    {
        Order newOrder = new Order(ordersTimeLimit, minDishQuantity, maxDishQuantity, possibleDishes);
        activeOrders.Add(newOrder);
        string details = "";
        foreach (string dishKey in newOrder.OrderDish.Keys)
        {
            details += newOrder.OrderDish[dishKey].ToString() + " " + dishKey + "\n";
        }
        visualOrders[activeOrders.IndexOf(newOrder)].detailsText.text = details;
    }
    IEnumerator OrderTimer()
    {
        yield return new WaitForEndOfFrame();
        foreach(Order activeOrder in activeOrders)
        {
            activeOrder.timeLimit -= Time.deltaTime;
            visualOrders[activeOrders.IndexOf(activeOrder)].timer.value = (activeOrder.timeLimit - 0) / (ordersTimeLimit - 0) * (1 - 0) + 0;
            if (activeOrder.timeLimit <= 0)
            {
                visualOrders[activeOrders.IndexOf(activeOrder)].detailsText.text = "";
                visualOrders[activeOrders.IndexOf(activeOrder)].transform.SetSiblingIndex(visualOrders.Count);
                closedOrderIndx.Add(activeOrders.IndexOf(activeOrder));
            }
        }
        RemoveOrder();
        StartCoroutine(OrderTimer());
    }
    private void RemoveOrder()
    {
        foreach (int index in closedOrderIndx)
        {
            activeOrders.RemoveAt(index);
        }
        closedOrderIndx.Clear();
        visualOrders.Clear();
        VisualOrderOrganizer();
    }
    private void VisualOrderOrganizer()
    {
        foreach (WorldOrder visualOrder in transform.GetComponentsInChildren<WorldOrder>())
        {
            visualOrders.Add(visualOrder);
        }
    }
}
