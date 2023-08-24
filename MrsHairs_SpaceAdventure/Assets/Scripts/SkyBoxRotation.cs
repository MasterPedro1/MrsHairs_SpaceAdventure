using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxRotation : MonoBehaviour
{
    [SerializeField] float speed;
    void FixedUpdate()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * speed);
    }
}
