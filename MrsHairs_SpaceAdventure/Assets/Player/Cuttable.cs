using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuttable : MonoBehaviour
{
    [SerializeField] private GameObject normalGameObject, cuttedGameObject;
    [SerializeField] private float itemDurability;
    [SerializeField] IngredientData ingData;
    float currentDurability, damageValue = 1;
    private void OnTriggerEnter(Collider other)
    {        
        if (!other.CompareTag("Knife"))
        {
            return;            
        }
        if (itemDurability > 0)
        {
            normalGameObject.SetActive(true);
            cuttedGameObject.SetActive(false);
            itemDurability -= damageValue;
        }
        if(itemDurability <= 0)
        {
            normalGameObject.SetActive(false);
            cuttedGameObject.SetActive(true);
            ingData.IsCutted = true;
        }
        Debug.Log(itemDurability);
    }
}
