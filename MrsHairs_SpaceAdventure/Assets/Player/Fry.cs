using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fry : MonoBehaviour
{
    [SerializeField] GameObject cookingBounds;
    [SerializeField] float cookingTime;
    Transform foodT;
    public bool IsCooking = false, IsCoolDownOn = false;
    ProgressBar progressBar;
    float secondTimer = 0f;

    Dish _dishData;

    private void Update()
    {
        if(!IsCooking || IsCoolDownOn)
        {
            return;
        }
        CookingCounter(_dishData.TotalCookingTime);
    }

    private void OnTriggerEnter(Collider other)
    {       
        if (other.CompareTag("Food"))
        {
            try
            {
                _dishData = other.GetComponent<Dish>();
                if(!_dishData.IsReadyToCook)
                {
                    return;
                }

                if (!IsCoolDownOn)
                {
                    //other.gameObject.transform.SetParent(this.transform, true);   
                    other.gameObject.TryGetComponent(out progressBar);
                    cookingBounds.SetActive(true);
                    foodT = other.transform;
                    progressBar.progressBarGO.SetActive(true);
                    foodT.transform.eulerAngles = new Vector3(0f, foodT.rotation.y, 0f);
                    IsCooking = true;
                    StartCoroutine(Cooking(_dishData.TotalCookingTime));
                }
            }
            catch
            {
                Debug.Log("Falta el componente Dish");
            }                   
            
        }

        if (other.CompareTag("Ingredient"))
        {
            if (!IsCoolDownOn)
            {
                try
                {
                    var ingDta = other.GetComponent<IngredientData>();
                    switch (ingDta.IngTypes)
                    {
                        case IngredientData.IngredientTypes.IsFryble:
                            break;
                    }

                    ingDta.IsFryed = true;
                }
                catch 
                {
                    
                }
            }
        }
    }




    private void CookingCounter(float maxTime)
    {        
        secondTimer += Time.deltaTime;
        progressBar.SetMaxValue(cookingTime);
        progressBar.ShowProgress(secondTimer);
        if (secondTimer >= maxTime)
        {
            secondTimer = 0f;
        }
        Debug.Log(secondTimer.ToString());
    }


    private IEnumerator Cooking(float time)
    {        
            foodT.gameObject.transform.SetParent(this.transform, true);
            foodT.position = cookingBounds.transform.position;
            
        yield return new WaitForSeconds(time);
            cookingBounds.SetActive(false);
            IsCooking = false;
           _dishData.IsDishFinished = true;
            foodT.transform.eulerAngles = new Vector3(foodT.rotation.x, foodT.rotation.y, foodT.rotation.z);
            progressBar.progressBarGO.SetActive(false);
            foodT.gameObject.transform.SetParent(null);
            StartCoroutine(CoolDown(3f));
    }


    private IEnumerator CoolDown(float coolDownTime)
    {
        IsCoolDownOn = true;
        yield return new WaitForSeconds(coolDownTime);
        IsCoolDownOn = false;
    }
}
