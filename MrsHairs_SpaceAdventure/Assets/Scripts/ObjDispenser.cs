using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjDispenser : MonoBehaviour
{
    [SerializeField] public  GameObject gObjPrefab;
    [SerializeField] private int spawnAmount;
    [HideInInspector] public List<GameObject> _ingredientsPool = new List<GameObject>();
    private Vector3 _spawnPosition;

    private void Awake()
    {
        _spawnPosition = transform.position + Vector3.up * 2.5f;
    }
    private void Start()
    {
        SetPool();
    }
    private void SetPool()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            _ingredientsPool.Add(PoolObj());
        }
    }
    public void ResetObjPosition(Transform obj)
    {
        obj.position = _spawnPosition;
    }
    private GameObject PoolObj()
    {
        return Instantiate(gObjPrefab, _spawnPosition, transform.rotation);
    }
}
