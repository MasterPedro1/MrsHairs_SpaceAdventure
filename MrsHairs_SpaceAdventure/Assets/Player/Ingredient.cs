using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ingredients/New Ingredient")]
public class Ingredient : ScriptableObject
{
    public string IngredientName;
    public enum IngredientTypes { IsCuttable, IsFryble, IsBoth }
    public IngredientTypes misTipos;
    public float cookingTime;

}
