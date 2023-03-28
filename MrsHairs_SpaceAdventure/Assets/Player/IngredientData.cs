using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientData : MonoBehaviour
{
    [SerializeField] Ingredient ingredient;
    public string IngName;
    public bool IsCutted, IsFryed;
    public enum IngredientTypes
    { 
        IsCuttable, IsFryble, IsBoth 
    }
    public IngredientTypes IngTypes;

    public enum IngredientCookingState
    {
        Azul, Rojo, TerminoMedio, TresCuartos, BienCocido
    }
    public IngredientCookingState IngCookingState;
    private void Awake()
    {
        IngName = ingredient.IngredientName;
        IsCutted = false;
        IsFryed = false;    
    }
}
