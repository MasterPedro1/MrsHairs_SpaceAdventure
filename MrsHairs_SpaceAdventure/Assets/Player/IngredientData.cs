using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientData : MonoBehaviour
{
    [SerializeField] Ingredient ingredient;
    public string IngName;
    public float CTime;

    private void Awake()
    {
        IngName = ingredient.IngredientName;
        CTime = ingredient.cookingTime;
    }
}
