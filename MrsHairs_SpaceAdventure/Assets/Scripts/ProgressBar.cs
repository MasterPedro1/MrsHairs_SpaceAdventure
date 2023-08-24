using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] Slider progressSlider;
    public GameObject progressBarGO;
    private void Awake()
    {
        //progressSlider = GetComponent<Slider>();
        progressBarGO.SetActive(false);
    }

    public void ShowProgress(float progress)
    {
        progressSlider.value = progress;
    }

    public void SetMaxValue(float maxValue)
    {
        progressSlider.maxValue = maxValue;
        progressSlider.value = maxValue;
    }
}