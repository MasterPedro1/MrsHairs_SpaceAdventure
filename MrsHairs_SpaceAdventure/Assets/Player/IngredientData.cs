using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientData : MonoBehaviour
{
    [SerializeField] Ingredient ingredient;
    public string IngName;
    public bool IsMeat;

    public enum IngredientTypes
    {
        IsCuttable, IsFryable, IsBoth
    }
    public IngredientTypes IngTypes;
    public bool IsCutted;

    [Header("Fryable Settings")]
    public bool IsFryed;
    public float CookingTime;
    public enum IngredientCookingState
    {
        Azul, Rojo, TerminoMedio, TresCuartos, BienCocido
    }
    public IngredientCookingState IngCookingState;


    private void Awake()
    {
        IngName = ingredient.IngredientName;
        CookingTime = ingredient.cookingTime;
        IsCutted = false;
        IsFryed = false;    
    }
}
