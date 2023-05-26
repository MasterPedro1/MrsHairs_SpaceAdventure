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

        //material.EnableKeyword("_EMISSION");
        material.SetFloat("_Intensity", 7);
    }

    public void GlowDown()
    {
        material = rendererMat.GetComponent<Renderer>().material;

        //material.EnableKeyword("_EMISSION");
        material.SetFloat("_Intensity", 1.4f);
    }
}
