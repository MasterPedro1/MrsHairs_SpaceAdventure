using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cuttable : MonoBehaviour
{
    [SerializeField] private GameObject normalGameObject, cuttedGameObject;
    [SerializeField] IngredientData ingData;
    [SerializeField] ProgressBar progressBar;
    public int ItemDurability;
    private int _itemD;

    int _damageValue = 1;
    private void Start()
    {
        _itemD = ItemDurability;
    }
    private void OnTriggerEnter(Collider other)
    {        
        if (!other.CompareTag("Knife"))
        {
            return;            
        }

        progressBar.progressBarGO.SetActive(true);
        progressBar.SetMaxValue(ItemDurability);
        progressBar.ShowProgress(ItemDurability);

        if (ItemDurability == 1) { }
        if (ItemDurability > 0)
        {
            normalGameObject.SetActive(true);
            cuttedGameObject.SetActive(false);
            ItemDurability -= _damageValue;
            progressBar.ShowProgress(ItemDurability);
        }
        if(ItemDurability <= 0)
        {
            normalGameObject.SetActive(false);
            cuttedGameObject.SetActive(true);
            ingData.IsCutted = true;
            progressBar.progressBarGO.SetActive(false);
        }
        Debug.Log(ItemDurability);
    }

    public void ResetGameObject()
    {
        ItemDurability = _itemD;
        normalGameObject.SetActive(true);
        cuttedGameObject.SetActive(false);
    }
}
