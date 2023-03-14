using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientData : MonoBehaviour
{
    [SerializeField] Ingredient ingredient;
    public string IngName;
    public bool IsCutted, IsFryed;

    private void Awake()
    {
        IngName = ingredient.IngredientName;
        IsCutted = false;
        IsFryed = false;    
    }
}
