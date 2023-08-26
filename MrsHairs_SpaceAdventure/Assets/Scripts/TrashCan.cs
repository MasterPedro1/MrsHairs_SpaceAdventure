using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static IngredientData;

public class TrashCan : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ingredient"))
        {
            try  
            {
                var restD = other.GetComponent<IngredientData>();
                restD.ResetData();
                if (restD.IngTypes == IngredientTypes.IsCuttable)
                {
                    try
                    {
                        var isC = GetComponent<Cuttable>();
                        isC.ResetGameObject();
                    }
                    catch { Debug.Log("TrashCan no pudo resetar el corte"); }
                }
            } catch { Debug.Log("Trash no pudo acceder a ingredient Data"); }
        }
        if (other.CompareTag("Food"))
        {
            try { other.GetComponent<Dish>().ResetDishData(); } catch { Debug.Log("Trash no pudo acceder a Dish Data"); }
        }
        other.gameObject.SetActive(false);
    }
}
