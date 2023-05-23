using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class TextPass : MonoBehaviour
{
    public GameObject[] textos;
    public InputActionProperty pinchAction;

    private int indiceActual = 0;
    private bool vrAction;

    public  bool istv;

    private GameObject textoActual;


    private void Start()
    {
        vrAction = pinchAction.action.ReadValue<bool>();

        
        for (int i = 1; i < textos.Length; i++)
        {
            textos[i].SetActive(false);
        }

       
        textoActual = textos[0];
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A) || vrAction)
        {

            CambiarTexto();


        }
    }

    public void CambiarTexto()
    {


        if (indiceActual < textos.Length - 1   || istv)
        {
            textoActual.SetActive(false);


            indiceActual = (indiceActual + 1) % textos.Length;


            textos[indiceActual].SetActive(true);
            textoActual = textos[indiceActual];
        }
        else if (!istv)
        {
            gameObject.SetActive(false);
        }
        
    }

}
