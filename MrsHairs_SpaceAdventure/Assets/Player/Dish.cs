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

    IngredientData _ingData;
    List<string> ingNames = new List<string>();
    List<string> IngredientsNames = new List<string>();
    int counter = 0;
    bool areAllIngredients = false;
    bool _isIngredientReady;

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
            try
            {
                _ingData = other.GetComponent<IngredientData>();
            }
            catch
            {
                Debug.Log("Algo salió mal al obtener Ingredient Data");
            }

            if (IsIngredientReady())
            {
                AddIngredientsToList();
                CheckIngredients();
            }

            if (areAllIngredients)
            {
                other.gameObject.SetActive(false);
                preDish.SetActive(false);
                finishedDish.SetActive(true);
                IsReadyToCook = true;
            }
        }
    }


    public void AddIngredientsToList()
    {
        ingNames.Add(_ingData.IngName);
        IngredientsNames = ingNames.Distinct().ToList();
        ingNames.Clear();
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


    public bool IsIngredientReady()
    {
        switch (_ingData.IngTypes)
        {
            case IngredientData.IngredientTypes.IsCuttable:
                if (_ingData.IsCutted) return true;
                break;

            case IngredientData.IngredientTypes.IsFryble:
                if (_ingData.IsFryed)
                {
                    /*switch(_ingData.IngCookingState)
                    {
                        case IngredientData.IngredientCookingState.Azul:

                            break;

                        case IngredientData.IngredientCookingState.Rojo:

                            break;

                        case IngredientData.IngredientCookingState.TerminoMedio:

                            break;

                        case IngredientData.IngredientCookingState.TresCuartos:

                            break;

                        case IngredientData.IngredientCookingState.BienCocido:

                            break;
                    }*/
                    return true;
                }
                break;

            case IngredientData.IngredientTypes.IsBoth:
                if (_ingData.IsCutted && _ingData.IsFryed) return true;
                break;
        }
        return false;
    }    
}
