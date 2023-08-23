using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjDispenser : MonoBehaviour
{
    [SerializeField] public  GameObject gObjPrefab;
    [SerializeField] private int spawnAmount;
    [HideInInspector] public List<GameObject> _ingredientsPool = new List<GameObject>();
    [SerializeField] Transform _spawnPosition;

    private void Awake()
    {
        //_spawnPosition = transform.position + Vector3.up * 2.5f;
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
        obj.position = _spawnPosition.position;
    }
    private GameObject PoolObj()
    {
        GameObject objt = Instantiate(gObjPrefab, _spawnPosition.position, transform.rotation);
        objt.SetActive(false);
        return objt;
    }

    [ContextMenu("Get Item")]
    public void GetObject()
    {
        for (int i = 0; i < _ingredientsPool.Count; i++)
        {
            if (!_ingredientsPool[i].gameObject.activeInHierarchy)
            {
                ResetObjPosition(_ingredientsPool[i].transform);
                _ingredientsPool[i].SetActive(true);
                try { _ingredientsPool[i].gameObject.GetComponent<IngredientData>().ResetData(); } catch { }
                break;
            }
        }
    }
}
