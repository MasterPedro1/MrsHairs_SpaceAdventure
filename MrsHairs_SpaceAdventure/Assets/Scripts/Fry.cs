using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fry : MonoBehaviour
{
    [SerializeField] GameObject cookingBounds;
    [SerializeField] Transform parentTransform;
    [SerializeField] float cookingTime;
    [SerializeField] string meatName;
    public bool IsCooking = false, IsCoolDownOn = false;

    Transform _foodT;
    ProgressBar _progressBar;
    float _secondTimer = 0f, _currentCookingState, _percentageMeat;
    Dish _dishData;
    IngredientData _ingDta;
    Rigidbody _otherRb;

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

            //Debug.Log("No entro el try");

            try
            {
                Debug.Log("Entro el try");
                _dishData = other.GetComponent<Dish>();
                _otherRb = other.GetComponent<Rigidbody>();
                if(!_dishData.IsReadyToCook) { return; }
                if (_dishData.IsDishFinished) { return; }
                if (!IsCoolDownOn)
                {
                    //other.gameObject.transform.SetParent(parentTransform, true);
                    //_otherRb.constraints = RigidbodyConstraints.FreezeAll;

                    cookingTime = _dishData.TotalCookingTime;
                    other.gameObject.TryGetComponent(out _progressBar);
                    //cookingBounds.SetActive(true);
                    _foodT = other.transform;
                    other.transform.localScale = Vector3.one;
                    _progressBar.progressBarGO.SetActive(true);
                    _foodT.transform.eulerAngles = new Vector3(0f, _foodT.rotation.y, 0f);
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
                    IsCooking = true;
                    _dishData.IsDishCooking = true;
                    _dishData.CheckIfCooking();
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
                    //other.GetComponent<Rigidbody>().isKinematic = true;
                    _ingDta = other.GetComponent<IngredientData>();
                    _progressBar = other.GetComponent<ProgressBar>();
                    cookingTime = _ingDta.CookingTime;

                    if (_ingDta.IsFryed) return;

                    if (IsCooking) return;
                    
                    if (_ingDta.IsMeat)
                    {
                        Debug.Log("Es carne");
                        //other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                        /*other.gameObject.transform.SetParent(parentTransform, true);
                        */
                        other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                        other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
                        other.gameObject.transform.rotation = Quaternion.identity;
                        other.transform.position = parentTransform.position;
                        _progressBar.progressBarGO.SetActive(true);
                        IsCooking = true;
                        return;
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
                if (_ingDta.IsFryed) return;
                if (IsCooking) return;

                other.gameObject.transform.SetParent(null);
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                other.GetComponent<Rigidbody>().isKinematic = false;
                if (_ingDta.IsMeat)
                {
                    _progressBar.progressBarGO.SetActive(false);
                    FinishMeat();
                    IsCooking = false;
                    StartCoroutine(CoolDown(0.5f));
                    return;
                }
                IsCooking = false;
                
                StartCoroutine(CoolDown(0.5f));
            } catch { }
            
        }
    }


    private void FinishMeat()
    {
        CheckMeatProgress();
        CheckMeatState();
        StartCoroutine(CoolDown(.5f));
        _ingDta.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        _ingDta.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        _ingDta.IsFryed = true;
        _progressBar.progressBarGO.SetActive(false); 
        Debug.Log(_ingDta.IngCookingState.ToString());
    }

    private void CookingCounter(float maxTime)
    {        
        _secondTimer += Time.deltaTime;
        _progressBar.SetMaxValue(cookingTime);
        _progressBar.ShowProgress(_secondTimer);
        if (_secondTimer >= maxTime)
        {
            IsCooking = false;
            {
                //_progressBar.gameObject.SetActive(false);
            }
            try { if (_ingDta.IsMeat) { FinishMeat(); } } catch { }
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
            //_foodT.gameObject.transform.SetParent(transform.parent, true);
            //_foodT.position = cookingBounds.transform.position;
            
        yield return new WaitForSeconds(time);
            cookingBounds.SetActive(false);
            IsCooking = false;
            _dishData.IsDishFinished = true;
            _foodT.transform.eulerAngles = new Vector3(_foodT.rotation.x, _foodT.rotation.y, _foodT.rotation.z);
            _progressBar.progressBarGO.SetActive(false);
            _foodT.gameObject.transform.SetParent(null);
            _otherRb.constraints = RigidbodyConstraints.None;
            _dishData.IsDishCooking = false;
            _dishData.CheckIfCooking();
            StartCoroutine(CoolDown(.6f));
    }


    private IEnumerator CoolDown(float coolDownTime)
    {
        IsCoolDownOn = true;
        yield return new WaitForSeconds(coolDownTime);
        IsCoolDownOn = false;
    }
}
