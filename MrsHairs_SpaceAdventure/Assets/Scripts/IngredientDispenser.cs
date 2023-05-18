using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class IngredientDispenser : MonoBehaviour
{
    [SerializeField] private GameObject ingredientPrefab;
    [SerializeField] Transform spawnPosition;
    [SerializeField] float spawnAmount;
    [SerializeField] private int dispenserCapacity, dispenserMaxCapacity;
    private ObjectPool<GameObject> _ingredientsPool;


    private void Start()
    {
        SetPool();
    }


    public void SetPool()
    {
        _ingredientsPool = new ObjectPool<GameObject>(() => { return Instantiate(ingredientPrefab); },
        ingredientPrefab => { ingredientPrefab.SetActive(true); },
        ingredientPrefab => { ingredientPrefab.SetActive(false); },
        ingredientPrefab => { Destroy(ingredientPrefab); },
        false, dispenserCapacity, dispenserMaxCapacity);
    }


    [ContextMenu("Get Ingredient")]
    public void GetIngredient()
    {
        for (int i = 0; i <= spawnAmount; i++)
        {
            GameObject ingredient = _ingredientsPool.Get();
            ingredient.transform.position = spawnPosition.position;
            DeactivateIngredient(ingredient);
        }
    }


    [ContextMenu("Release Ingredient")]
    public void DeactivateIngredient(GameObject ingredient)
    {
        _ingredientsPool.Release(ingredient);
    }
}
