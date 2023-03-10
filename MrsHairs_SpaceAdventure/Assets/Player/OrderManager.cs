using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [Header("Orders to appear")]
    public int orderListLimit = 10;
    public float orderAdditionTimer = 7.5f;
    public List<Order> orderList = new List<Order>();

    [Header("Order details")]
    public float _orderTimeLimit = 30;
    public List<Dish> possibleDishes = new List<Dish>();
    public int minDishQuantity = 2, maxDishQuantity = 4;
    public List<OrderDishes> dishesNeeded = new List<OrderDishes>();
    
    IEnumerator PlaceOrder()
    {
        while (true)
        {
            if (orderList.Count < orderListLimit)
            {
                
            }
        }
        yield return new WaitForSeconds(orderAdditionTimer);
    }
    IEnumerator CreateOrder()
    {
        // Cloned list to pick dishes from
        List<Dish> dishes = possibleDishes;
        // Amount of different dishes used for this order
        int numberOfNextDishes = Random.Range(0, dishes.Count);
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
            dishesNeeded.Add(nextDeliverOrder);
            numberOfNextDishes--;
        }
        yield return null;
    }
}
[System.Serializable]
public class Order
{
    public float orderTime;
    public int minDishQuantity, maxDishQuantity;
    public List<OrderDishes> dishesNeeded = new List<OrderDishes>();
}

[System.Serializable]
public class OrderDishes
{
    public int dishQuantity;
    public Dish dishToGive;
}
