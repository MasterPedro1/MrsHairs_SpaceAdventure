using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowObjects : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] Renderer rendererMat;
    [SerializeField] bool isGrabbable = true;
    bool _isGrabbed = false;

    private void Start()
    {
        GlowDown();
    }

    public void GlowUp()
    {
        if (isGrabbable)
        {
            if (_isGrabbed) return;
        }
        material = rendererMat.GetComponent<Renderer>().material;
        //material.EnableKeyword("_EMISSION");
        material.SetFloat("_Intensity", 7);
        material.SetColor("_Color", new Color(0.1191339f, 1f, 0f, 0f));
        
    }

    public void GlowDown()
    {
        if (isGrabbable)
        {
            if (_isGrabbed) return;
        }
        material = rendererMat.GetComponent<Renderer>().material;

        //material.EnableKeyword("_EMISSION");
        material.SetFloat("_Intensity", 1.4f);
        material.SetColor("_Color", new Color(0f, 0.6884818f, 1f, 0f));
    }

    public void ObjectGrabbed()
    {
        _isGrabbed = true;
    }

    public void ObjectDropped()
    {
        _isGrabbed = false;
        GlowDown();
    }

    public void DisableGlow()
    {
        if (_isGrabbed)
        {
            material = rendererMat.GetComponent<Renderer>().material;
            material.SetFloat("_Intensity", 0f);
            material.SetColor("_Color", new Color(0f, 0f, 0f, 0f));
        }
    }
}
