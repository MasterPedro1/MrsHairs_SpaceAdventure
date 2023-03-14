using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Dish : MonoBehaviour
{
    [Header("Dish Requirements")]
    public string DishName;
    public int NumberOfIngredients;
    public float TotalCookingTime;
    public List<Ingredient> Ingredients = new List<Ingredient>();

    [Header("Dish")]
    [SerializeField] GameObject preDish, finishedDish;
    [SerializeField] string tagName;
    public bool IsReadyToCook = false, IsDishFinished = false;

    List<string> ingNames = new List<string>();
    List<string> IngredientsNames = new List<string>();
    int counter = 0;
    bool areAllIngredients = false;

    private void Start()
    {
        preDish.SetActive(true);
        finishedDish.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == tagName)
        {
            if (IsReadyToCook) return;

            Debug.Log(other.tag);
            try
            {                
                var IngData = other.GetComponent<IngredientData>();
                
                ingNames.Add(IngData.IngName);
                IngredientsNames = ingNames.Distinct().ToList();
                ingNames.Clear();
                //IngredientsNames.Add(IngData.IngName);
            }
            catch
            {
                Debug.Log("Te faltó el ");
            }
            if (IngredientsNames.Count >= NumberOfIngredients) 
            { 
                CheckIngredients();
                if (areAllIngredients)
                {
                    other.gameObject.SetActive(false);
                    preDish.SetActive(false);
                    finishedDish.SetActive(true);
                    IsReadyToCook = true;
                }
            }
        }
    }

    public void CheckIngredients()
    {        
        
        for (int i = 0; i < IngredientsNames.Count; i++)
        { 
            for (int j = 0; j < Ingredients.Count; j++)
            {
                if (Ingredients[j].IngredientName == IngredientsNames[i])
                {
                    counter++;
                    if (counter >= NumberOfIngredients)
                    {
                        areAllIngredients = true;
                        IngredientsNames.Clear();
                    }
                }
            }
        }
    }

    
}
