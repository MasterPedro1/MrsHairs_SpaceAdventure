using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Transform[] target;
    public Slider vidaSlider;
    public GameObject slider;
    public GameObject Letrero;
    public float vida = 100;
    public float slowingRadios = 4;
    public Shoot sh;

    
    public float speed;
    public float speedNormal;
    private int currentPoint = 0;

    private void Start()
    {
        speedNormal = speed;
    }

    void Update()
    {

        vidaSlider.value = vida;
        float currentvida = vida;
        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }

        Arrival();

       
    }

    public void QuitarVida()
    {
        vida--;
    }

    public void Slider()
    {
        slider.gameObject.SetActive(true);
    }


    public void Arrival()
    {

        this.transform.LookAt(Camera.main.transform);

        Vector3 direction = target[currentPoint].position - transform.position;

        float distance = direction.magnitude;

        if (distance < 0.1f)
        {
            currentPoint++;
            if (currentPoint >= target.Length)
            {
                currentPoint--;
                speed = 0;
            }
        }

        direction.Normalize();

        transform.position += direction * speed * Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

}
