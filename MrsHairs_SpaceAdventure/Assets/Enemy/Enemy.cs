using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public Slider vidaSlider;
    public float vida = 100;
    public float slowingRadios = 4;
    public Shoot sh;

    [SerializeField] private Vector3 velocity;
    private Vector3 steering;
    public float speed;
    public float speedNormal;


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

        if (sh.isHitting == true)
        {
            QuitarVida();
            Slowing();
        }
        else vida += currentvida;
        speed = speedNormal;
    }

    public void QuitarVida()
    {
        vida--;
    }

    public void Slowing()
    {
        speed = 7;
    }

    public void Rapiding()
    {
        speed = 4;
    }

    public void Arrival()
    {

        this.transform.LookAt(Camera.main.transform);


        Vector3 desvel = (target.position - transform.position);
        float distance = desvel.magnitude;

        if (distance < slowingRadios)
        {
            steering = desvel - velocity * (distance / slowingRadios);
        }
        else
        {
            steering = desvel - velocity;
        }
        steering = desvel - velocity;
        velocity += steering;
        transform.position += velocity * Time.deltaTime / speed;


    }


}
