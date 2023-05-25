using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowObjects : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] Renderer rendererMat;
    public void GlowUp()
    {
        material = rendererMat.GetComponent<Renderer>().material;

        material.EnableKeyword("_EMISSION");
    }
}
