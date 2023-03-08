using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    [Header("Dish Requirements")]
    public string DishName;
    public int NumberOfIngredients;
    public float TotalCookingTime;
    public Dictionary<string, string> NecessaryIngredients = new Dictionary<string, string>();

    [Header("Dish")]
    [SerializeField] string tagName;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == tagName)
        {

        }
    }
}
