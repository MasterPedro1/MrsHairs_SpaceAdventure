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
        StartCoroutine(PlaceOrder());
        StartCoroutine(OrderTimer());
    }  
    public void CheckDelivery(WorldOrder orderToCheck, Plate plateTocheck)
    {
        int orderIndx = visualOrders.IndexOf(orderToCheck);
        if (activeOrders[orderIndx].OrderDish.Equals(plateTocheck.plateDishes)) 
        {
            ClearVisualOrder(orderIndx);
            closedOrderIndx.Add(orderIndx);
            print("Correct order");
            
        }
        else
        {
            print("Incorrect order");
        }
        Destroy(plateTocheck.gameObject);
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
                ClearVisualOrder(activeOrders.IndexOf(activeOrder));
                closedOrderIndx.Add(activeOrders.IndexOf(activeOrder));
            }
        }
        RemoveOrder();
        StartCoroutine(OrderTimer());
    }
    private void ClearVisualOrder(int indx)
    {
        visualOrders[indx].detailsText.text = "";
        visualOrders[indx].transform.SetSiblingIndex(visualOrders.Count);
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
