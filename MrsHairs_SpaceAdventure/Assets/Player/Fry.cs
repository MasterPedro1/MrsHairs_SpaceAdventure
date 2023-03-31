using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fry : MonoBehaviour
{
    [SerializeField] GameObject cookingBounds;
    [SerializeField] float cookingTime;
    [SerializeField] string meatName;
    public bool IsCooking = false, IsCoolDownOn = false;

    Transform _foodT;
    ProgressBar _progressBar;
    float _secondTimer = 0f, _currentCookingState, _percentageMeat;
    Dish _dishData;
    IngredientData _ingDta;

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
            try
            {
                _dishData = other.GetComponent<Dish>();
                if(!_dishData.IsReadyToCook) { return; }

                if (!IsCoolDownOn)
                {
                    //other.gameObject.transform.SetParent(this.transform, true);
                    cookingTime = _dishData.TotalCookingTime;
                    other.gameObject.TryGetComponent(out _progressBar);
                    cookingBounds.SetActive(true);
                    _foodT = other.transform;
                    _progressBar.progressBarGO.SetActive(true);
                    _foodT.transform.eulerAngles = new Vector3(0f, _foodT.rotation.y, 0f);
                    IsCooking = true;
                    StartCoroutine(Cooking(_dishData.TotalCookingTime));
                }
            }
            catch  { Debug.Log("Falta el componente Dish"); }                  
        }

        if (other.CompareTag("Ingredient"))
        {
            if (!IsCoolDownOn)
            {
                try
                {
                    _ingDta = other.GetComponent<IngredientData>();
                    _progressBar = other.GetComponent<ProgressBar>();
                    cookingTime = _ingDta.CookingTime;
                    if (_ingDta.IsFryed) return;

                    if (_ingDta.IngName == meatName)
                    {
                        Debug.Log("Cocina carne");
                        _progressBar.progressBarGO.SetActive(true);
                        IsCooking = true;
                        
                    }
                    _ingDta.IsFryed = true;
                }
                catch { return; }
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ingredient"))
        {
            try
            {
                CheckMeatProgress();
                CheckMeatState();
                
            }
            catch { Debug.Log("No es carne"); }
            IsCooking = false;
            StartCoroutine(CoolDown(3f));
        }
    }


    private void CookingCounter(float maxTime)
    {        
        _secondTimer += Time.deltaTime;
        _progressBar.SetMaxValue(cookingTime);
        _progressBar.ShowProgress(_secondTimer);
        if (_secondTimer >= maxTime)
        {
            _secondTimer = 0f;
        }
        //Debug.Log(_secondTimer.ToString());
    }


    private void CheckMeatProgress()
    {
        float maxCookingTime = _ingDta.CookingTime;
        _currentCookingState = _secondTimer;
        _percentageMeat = (_currentCookingState * 100f) / maxCookingTime;
        Debug.Log(_percentageMeat);
    }


    private void CheckMeatState()
    {
        if (_percentageMeat <= 0 && _percentageMeat < 25)
        {
            _ingDta.IngCookingState = IngredientData.IngredientCookingState.Azul;
        }
        if (_percentageMeat > 25 && _percentageMeat <= 40)
        {
            _ingDta.IngCookingState = IngredientData.IngredientCookingState.Rojo;
        }
        if (_percentageMeat > 40 && _percentageMeat <= 60)
        {
            _ingDta.IngCookingState = IngredientData.IngredientCookingState.TerminoMedio;
        }
        if (_percentageMeat > 60 && _percentageMeat <= 90)
        {
            _ingDta.IngCookingState = IngredientData.IngredientCookingState.TresCuartos;
        }
        if (_percentageMeat > 90)
        {
            _ingDta.IngCookingState = IngredientData.IngredientCookingState.BienCocido;
        }
    }


    private IEnumerator Cooking(float time)
    {        
            _foodT.gameObject.transform.SetParent(this.transform, true);
            _foodT.position = cookingBounds.transform.position;
            
        yield return new WaitForSeconds(time);
            cookingBounds.SetActive(false);
            IsCooking = false;
           _dishData.IsDishFinished = true;
            _foodT.transform.eulerAngles = new Vector3(_foodT.rotation.x, _foodT.rotation.y, _foodT.rotation.z);
            _progressBar.progressBarGO.SetActive(false);
            _foodT.gameObject.transform.SetParent(null);
            StartCoroutine(CoolDown(3f));
    }


    private IEnumerator CoolDown(float coolDownTime)
    {
        IsCoolDownOn = true;
        yield return new WaitForSeconds(coolDownTime);
        IsCoolDownOn = false;
    }
}
