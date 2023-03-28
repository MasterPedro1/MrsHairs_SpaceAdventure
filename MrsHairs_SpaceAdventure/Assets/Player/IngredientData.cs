using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientData : MonoBehaviour
{
    [SerializeField] Ingredient ingredient;
    public string IngName, IngType;
    public bool IsCuttable, IsFryble, IsBoth;
    public bool IsCutted, IsFryed;

    private void Awake()
    {
        IngName = ingredient.IngredientName;
        IsCuttable = ingredient.IsCuttable;
        IsFryble = ingredient.IsFryble;
        IsBoth = ingredient.IsBoth;

        IsCutted = false;
        IsFryed = false;    
    }
}
