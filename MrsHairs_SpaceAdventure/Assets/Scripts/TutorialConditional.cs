using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialConditional : MonoBehaviour
{
    [SerializeField] UnityEvent finishTutorial;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            if (collision.gameObject.GetComponentInChildren<Dish>().IsDishFinished)
            {
                finishTutorial.Invoke();
            }
        }
    }
}
