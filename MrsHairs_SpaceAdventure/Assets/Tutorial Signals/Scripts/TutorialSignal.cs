using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialSignal : MonoBehaviour
{
    [SerializeField, Header("Signal transform"), Tooltip("Reference of the object used as signal in the scene")]
    private Transform signalObj;
    [SerializeField, Space(1.5f), Header("Movement attributes"), Tooltip("Speed of the translation in the scene")]
    private float displacementSpeed = 3.25f; 
    [SerializeField, Tooltip("Degrees to rotate per second")] 
    private float rotationSpeed = 4.5f;
    [SerializeField, Space(.45f), Header("Displacement coordinates"), Tooltip("Values added to the initial signal position")]
    private Vector3 displacement = new Vector3 (0, 2.5f, 0);

    [HideInInspector] public UnityEvent _activateSignal, _deactivateSignal;

    private bool _movePositive;
    private Vector3 _ogSignalPosition;

    private void Awake()
    {
        _ogSignalPosition = signalObj.position;
        _movePositive = true;

        _activateSignal.AddListener(() => StartCoroutine(RotateSignal()));
        _activateSignal.AddListener(() => StartCoroutine(DisplaceSignal()));

        _deactivateSignal.AddListener(() => DestroySignal());
    }
    private void OnEnable()
    {
        CallSignalOn();
    }
    public void CallSignalOn()
    {
        _activateSignal.Invoke();
    }
    public void CallSignalOff()
    {
        _deactivateSignal.Invoke();
    }
    private IEnumerator RotateSignal()
    {
        yield return new WaitForEndOfFrame();
        signalObj.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        StartCoroutine(RotateSignal());
    }
    private IEnumerator DisplaceSignal()
    {
        yield return new WaitForEndOfFrame();
        Vector3 nextDisplacementCoord = _movePositive ? _ogSignalPosition + displacement : _ogSignalPosition - displacement;
        signalObj.position = Vector3.MoveTowards(signalObj.position, nextDisplacementCoord, displacementSpeed * Time.deltaTime);
        if (signalObj.position == nextDisplacementCoord) { _movePositive = !_movePositive; }
        StartCoroutine (DisplaceSignal());
    }
    private void DestroySignal()
    {
        Destroy(gameObject);
    } 
}
