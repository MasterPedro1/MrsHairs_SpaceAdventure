using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish2 : MonoBehaviour
{
    [Header("Dish Requirements")]
    public string DishName;
    [SerializeField] private int NumberOfIngredients;
    [SerializeField] private float TotalCookingTime;
    public List<Ingredient> Ingredients = new List<Ingredient>();
    private enum MeatState { Azul, Rojo, TerminoMedio, TresCuartos, BienCocido }
    [SerializeField] private MeatState MeatFryedState;

    [Header("Dish")]
    [SerializeField] private string tagName = "Ingredient";
    public GameObject preDish, finishedDish;
    [SerializeField] private bool IsReadyToCook = false, IsDishFinished = false;

    private IngredientData _ingData;
    private HashSet<string> IngredientsNames = new HashSet<string>();

    private void Start()
    {
        preDish.SetActive(true);
        finishedDish.SetActive(false);
        NumberOfIngredients = Ingredients.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagName) && !IsReadyToCook)
        {
            try { _ingData = other.GetComponent<IngredientData>(); }
            catch { Debug.Log("Algo salió mal al obtener Ingredient Data"); }

            if (IsIngredientReady())
            {
                AddIngredientToList();
                CheckIngredients();
            }

            if (IsDishFinished)
            {
                other.gameObject.SetActive(false);
                preDish.SetActive(false);
                finishedDish.SetActive(true);
                IsReadyToCook = true;
                _ingData.ResetData();
            }
        }
    }

    private void AddIngredientToList()
    {
        IngredientsNames.Add(_ingData.IngName);
    }

    private void CheckIngredients()
    {
        int counter = 0;
        foreach (Ingredient ingredient in Ingredients)
        {
            if (IngredientsNames.Contains(ingredient.IngredientName))
            {
               
                    counter++;
                    if (counter >= NumberOfIngredients)
                    {
                        IsDishFinished = true;
                        IngredientsNames.Clear();
                        return;
                    }
               
            }
        }
    }

    private bool IsIngredientReady()
    {
        switch (_ingData.IngTypes)
        {
            case IngredientData.IngredientTypes.IsCuttable:
                return _ingData.IsCutted;

            case IngredientData.IngredientTypes.IsFryable:
                if (_ingData.IsMeat && MeatFryedState.ToString() != _ingData.IngCookingState.ToString())
                    return false;
                return _ingData.IsFryed;

            case IngredientData.IngredientTypes.IsBoth:
                if (_ingData.IsMeat && MeatFryedState.ToString() != _ingData.IngCookingState.ToString())
                    return false;
                return _ingData.IsCutted && _ingData.IsFryed;

            default:
                return false;
        }
    }

}
