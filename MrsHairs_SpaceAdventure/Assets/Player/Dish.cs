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
    public List<string> IngredientsNames = new List<string>();
    public float TotalCookingTime;
    public List<Ingredient> Ingredients = new List<Ingredient>();

    [Header("Dish")]
    [SerializeField] GameObject preDish, finishedDish;
    [SerializeField] string tagName;
    List<string> ingNames = new List<string>();
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
            Debug.Log(other.tag);
            try
            {                
                var IngData = other.GetComponent<IngredientData>();
                
                ingNames.Add(IngData.IngName);
                IngredientsNames = ingNames.Distinct().ToList();
                //IngredientsNames.Add(IngData.IngName);
            }
            catch
            {
                Debug.Log("Te faltó el ");
            }
            if (IngredientsNames.Count == NumberOfIngredients) 
            { 
                CheckIngredients();
                if (areAllIngredients)
                {
                    other.gameObject.SetActive(false);
                    preDish.SetActive(false);
                    finishedDish.SetActive(true);
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

                    }
                }
            }
        }
    }

    
}
