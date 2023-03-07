using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    [SerializeField]
    private List<Dish> possibleDishes = new List<Dish>();
    [SerializeField]
    private int minDishQuantity = 2, maxDishQuantity = 4;

    public List<DishOrder> dishesNeeded = new List<DishOrder>();

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
            DishOrder nextDeliverOrder = new DishOrder();
            nextDeliverOrder.dishQuantity = Random.Range(minDishQuantity, maxDishQuantity);
            nextDeliverOrder.dishToGive = nextDish;
            dishesNeeded.Add(nextDeliverOrder);
            numberOfNextDishes--;
        }
        yield return null;
    }
    
}

[System.Serializable]
public class DishOrder
{
    public int dishQuantity;
    public Dish dishToGive;
}
