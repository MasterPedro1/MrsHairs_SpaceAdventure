using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientData : MonoBehaviour
{
    [SerializeField] Ingredient ingredient;
    public string IngName, IngType;
    public enum IngredientTypes { IsCuttable, IsFryble, IsBoth }
    public bool IsCutted, IsFryed;

    private void Awake()
    {
        IngName = ingredient.IngredientName;
        IsCutted = false;
        IsFryed = false;    
    }
}
