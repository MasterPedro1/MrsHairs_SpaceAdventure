using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientData : MonoBehaviour
{
    [SerializeField] Ingredient ingredient;
    [HideInInspector] public string IngName;
    public bool IsMeat;

    public enum IngredientTypes
    {
        IsCuttable, IsFryable, IsBoth
    }
    public IngredientTypes IngTypes;
     public bool IsCutted;

    [Header("Fryable Settings")]
     public bool IsFryed;
    [HideInInspector] public float CookingTime;
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


    public void ResetData()
    {
        IngCookingState = IngredientCookingState.Azul;
        IsCutted = false;
        IsFryed = false;
        if (IngTypes == IngredientTypes.IsCuttable)
        {
            try
            {
                var isC = GetComponent<Cuttable>();
                isC.ResetGameObject();
            } catch { }
        }
    }
}
