using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Order
{
    public float timeLimit;
    public Dictionary<string, int> OrderDish = new Dictionary<string, int>();
    public Order(float managerTime, int minAmount, int maxAmount, List<Dish> managerDishes)
    {
        this.timeLimit = managerTime;

        // Cloned list to pick dishes from
        List<Dish> possibleDishes = new List<Dish>();
        for (int i = 0; i < managerDishes.Count; i++) { possibleDishes.Add(managerDishes[i]); }

        // Amount of different dishes used for this order
        int numberOfNextDishes = Random.Range(1, possibleDishes.Count + 1);
        while (numberOfNextDishes > 0)
        {
            // Choose the dish to add to the order
            int nextDishID = Random.Range(0, possibleDishes.Count);
            Dish nextDish = possibleDishes[nextDishID];

            // Removes the dish from the cloned list so it doesn't reappear
            possibleDishes.RemoveAt(nextDishID);

            // Creates a new order with the required amount of the dish previously selected
            
            OrderDish.Add(nextDish.DishName, Random.Range(minAmount, maxAmount));
            numberOfNextDishes--;
        }
    }
}
