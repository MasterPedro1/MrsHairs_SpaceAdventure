using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [Header("Manager variables")]
    public bool createOrders = true;
    public List<UIOrder> visualOrders = new List<UIOrder>();

    [Space(2.5f), Header("Orders to appear")]
    public int orderListLimit = 5;
    public float orderAdditionTimer = 7.5f;
    public List<Order> orderList = new List<Order>();

    [Space(2.5f), Header("Order details")]
    public float ordersTimeLimit = 30;
    public int minDishQuantity = 2, maxDishQuantity = 4;
    public List<Dish> possibleDishes = new List<Dish>();

    private void Awake()
    {
        foreach(UIOrder visualOrder in transform.GetComponentsInChildren<UIOrder>())
        {
            visualOrders.Add(visualOrder);
        }
    }

    private void ShowOrders()
    {
        for(int i = 0; i < orderList.Count; i++)
        {
            //visualOrders[i].detailsText = orderList[i].
        }
    }

    IEnumerator PlaceOrder()
    {
        yield return new WaitForSeconds(orderAdditionTimer);

        if (createOrders && orderList.Count < orderListLimit)
        {
            Order newOrder = CreateOrder();
            orderList.Add(newOrder);
            string details = "";
            for(int i = 0; i < newOrder.dishesNeeded.Count; i++)
            {
                details+=newOrder.dishesNeeded[i].dishQuantity + " " + newOrder.dishesNeeded[i].dishToGive.dishName + "\n";
            }
            visualOrders[orderList.IndexOf(newOrder)].detailsText.text = details;
        }
        StartCoroutine(PlaceOrder());
    }
    private Order CreateOrder()
    {
        // Cloned list to pick dishes from
        List<Dish> dishes = new List<Dish>();
        for (int i = 0; i < possibleDishes.Count; i++)
        {
            dishes.Add(possibleDishes[i]);
        }
        // Create a new order to add it to the list
        Order nextOrder = new Order();
        // Amount of different dishes used for this order
        int numberOfNextDishes = Random.Range(1, dishes.Count + 1);
        while(numberOfNextDishes > 0)
        {
            // Choose the dish to add to the order
            int nextDishID = Random.Range(0, dishes.Count);
            Dish nextDish = dishes[nextDishID];
            // Removes the dish from the cloned list so it doesn't reappear
            dishes.RemoveAt(nextDishID);
            // Creates a new order with the required amount of the dish previously selected
            OrderDishes nextDeliverOrder = new OrderDishes();
            nextDeliverOrder.dishQuantity = Random.Range(minDishQuantity, maxDishQuantity);
            nextDeliverOrder.dishToGive = nextDish;
            nextOrder.dishesNeeded.Add(nextDeliverOrder);
            numberOfNextDishes--;
        }
        nextOrder.timeLimit = ordersTimeLimit;
        return nextOrder;
    }
    IEnumerator OrderTimer()
    {
        yield return new WaitForEndOfFrame();
        foreach(Order activeOrder in orderList)
        {
            activeOrder.timeLimit -= Time.deltaTime;
            if (activeOrder.timeLimit <= 0) activeOrder.timeLimit = ordersTimeLimit;
        }
        StartCoroutine(OrderTimer());
    }
    private void Start()
    {
        StartCoroutine(PlaceOrder());
    }
}


// Order classes

[System.Serializable]
public class Order
{
    public float timeLimit;
    public List<OrderDishes> dishesNeeded = new List<OrderDishes>();
}

[System.Serializable]
public class OrderDishes
{
    public int dishQuantity;
    public Dish dishToGive;
}
