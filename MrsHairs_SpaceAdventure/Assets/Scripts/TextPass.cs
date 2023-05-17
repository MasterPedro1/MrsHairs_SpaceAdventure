using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class TextPass : MonoBehaviour
{
    public TextMeshProUGUI[] textos;
    private int indiceActual = 0;
    public InputActionProperty pinchAction;
    private void Start()
    {
        // Desactiva todos los textos excepto el primero
        for (int i = 1; i < textos.Length; i++)
        {
            textos[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        // Verifica si se ha presionado el botón "A" del Oculus Quest 2
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Cambia al siguiente texto
            CambiarTexto();
        }
    }

    private void CambiarTexto()
    {
        // Desactiva el texto actual
        textos[indiceActual].gameObject.SetActive(false);

        // Incrementa el índice o vuelve al principio si alcanza el final
        indiceActual = (indiceActual + 1) % textos.Length;

        // Activa el siguiente texto
        textos[indiceActual].gameObject.SetActive(true);
    }
}
