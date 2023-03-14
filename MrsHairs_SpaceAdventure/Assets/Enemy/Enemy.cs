using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public Shoot shoot;
    public Slider vidaSlider;
    public float vida = 100;
    public float slowingRadios = 4;


    [SerializeField] private Vector3 velocity;
    private Vector3 steering;
    public float speed;



    private void Start()
    {
       
    }

    void Update()
    {
        if(shoot.isAEnemy == true)
        {
            vida--;
        }

        vidaSlider.value = vida;

        if(vida <= 0)
        {
            Destroy(this.gameObject);
        }

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
