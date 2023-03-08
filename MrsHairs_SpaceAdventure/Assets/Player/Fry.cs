using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fry : MonoBehaviour
{
    [SerializeField] GameObject cookingBounds;
    [SerializeField] float cookingTime;
    Transform foodT;
    GameObject foodBar;
    public bool IsCooking = false, IsCoolDownOn;
    ProgressBar progressBar;
    float secondTimer = 0f;

    private void Update()
    {
        if(!IsCooking || IsCoolDownOn)
        {
            return;
        }
        CookingCounter(cookingTime);
    }

    private void OnTriggerEnter(Collider other)
    {       
        if (other.CompareTag("Food"))
        {
            if (!IsCoolDownOn)
            {
                //other.gameObject.transform.SetParent(this.transform, true);   
                other.gameObject.TryGetComponent(out progressBar);
                cookingBounds.SetActive(true);
                foodT = other.transform;
                progressBar.progressBarGO.SetActive(true);
                foodT.transform.eulerAngles = new Vector3(0f, foodT.rotation.y, 0f);
                IsCooking = true;
                StartCoroutine(Cooking(cookingTime));
            }            
            
        }
    }


    private void CookingCounter(float maxTime)
    {        
        secondTimer += Time.deltaTime;
        progressBar.ShowProgress(cookingTime, secondTimer);
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
