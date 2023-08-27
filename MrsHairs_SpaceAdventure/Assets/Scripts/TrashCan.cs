using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static IngredientData;

public class TrashCan : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ingredient"))
        {
            try
            {
                var restD = other.gameObject.GetComponent<IngredientData>();
                restD.ResetData();
                if (restD.IngTypes == IngredientTypes.IsCuttable)
                {
                    try
                    {
                        var isC = GetComponent<Cuttable>();
                        isC.ResetGameObject();
                    }
                    catch { Debug.Log("TrashCan no pudo resetar el corte"); }
                    //other.gameObject.SetActive(false);
                }
            }
            catch { Debug.Log("Trash no pudo acceder a ingredient Data"); }
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Food"))
        {
            try { other.gameObject.GetComponent<Dish>().ResetDishData(); } catch { Debug.Log("Trash no pudo acceder a Dish Data"); }
            other.gameObject.SetActive(false);
        }
    }
}
