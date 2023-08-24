using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AdvancedInteractions : MonoBehaviour
{
    [SerializeField] UnityEvent advancedInteraction;

    public void InvokeAdvancedInteraction()
    {
        advancedInteraction.Invoke();
    }
}
