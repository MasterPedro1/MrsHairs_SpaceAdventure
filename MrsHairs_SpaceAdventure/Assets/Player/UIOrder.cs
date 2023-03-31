using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIOrder : MonoBehaviour
{
    public TextMeshProUGUI detailsText;
    public Slider timer;

    private void Awake()
    {
        detailsText = GetComponentInChildren<TextMeshProUGUI>();
        timer = GetComponentInChildren<Slider>();
    }
    //public float VisualTimer(float orderTime)
    //{
    //    //timer.value = 
    //
    //}
}
