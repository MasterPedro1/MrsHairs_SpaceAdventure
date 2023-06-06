
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Material material;
    private void Start()
    {
      
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CambiarColorAleatorio();
        }
    }

    private void CambiarColorAleatorio()
    {
        Color randomColor = Random.ColorHSV(); // Genera un color aleatorio

        material.SetColor("_EmissionColor", randomColor); // Cambia el color de emisión del material
        material.EnableKeyword("_EMISSION");
    }
}
