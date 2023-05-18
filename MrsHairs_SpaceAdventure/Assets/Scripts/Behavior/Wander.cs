using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    public Transform playerTransform;
    public float wanderRadius = 5f;
    public float wanderDistance = 10f;
    public float wanderJitter = 1f;
    public float runAwayDistance = 8f;
    public float runAwayForceMagnitude = 10f;
    public float maxSpeed = 5f;
    public Vector3 movementBounds = new Vector3(20f, 20f, 20f);

    private Vector3 wanderTarget;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetRandomWanderTarget();
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            // Calcula la distancia al jugador
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

            // Comportamiento de wander si el jugador está lejos
            if (distanceToPlayer > runAwayDistance)
            {
                Wander2();
            }
            else // Comportamiento de run away si el jugador está cerca
            {
                RunAway();
            }
        }

        // Limita la posición dentro de los límites establecidos
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -movementBounds.x, movementBounds.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, 4f , movementBounds.y);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, -movementBounds.z, movementBounds.z);
        transform.position = clampedPosition;
    }

    private void Wander2()
    {
        // Calcula la dirección hacia el objetivo de wander
        Vector3 wanderDirection = wanderTarget - transform.position;
        wanderDirection.Normalize();

        // Calcula una fuerza de wander aleatoria
        Vector3 randomOffset = Random.insideUnitSphere * wanderJitter;
        randomOffset.y = 0;
        wanderTarget += randomOffset;
        wanderTarget.Normalize();
        wanderTarget *= wanderRadius;

        // Calcula la fuerza de steering
        Vector3 desiredVelocity = wanderTarget + wanderDirection * wanderDistance;
        Vector3 steeringForce = desiredVelocity - rb.velocity;
        steeringForce = Vector3.ClampMagnitude(steeringForce, maxSpeed);

        // Aplica la fuerza al objeto
        rb.AddForce(steeringForce);
    }

    private void RunAway()
    {
        // Calcula la dirección hacia el jugador
        Vector3 playerDirection = transform.position - playerTransform.position;
        playerDirection.Normalize();

        // Calcula la fuerza de run away
        Vector3 runAwayForce = playerDirection * runAwayForceMagnitude;

        // Aplica la fuerza al objeto
        rb.AddForce(runAwayForce);
    }

    private void SetRandomWanderTarget()
    {
        wanderTarget = Random.insideUnitCircle.normalized * wanderRadius;
        wanderTarget.y = 0f;
    }
}
