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
        material.SetColor("_Color", new Color(0.1191339f, 1f, 0f, 0f));
        
    }

    public void GlowDown()
    {
        material = rendererMat.GetComponent<Renderer>().material;

        //material.EnableKeyword("_EMISSION");
        material.SetFloat("_Intensity", 1.4f);
        material.SetColor("_Color", new Color(0f, 0.6884818f, 1f, 0f));
    }
}
