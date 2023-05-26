using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenScreen : MonoBehaviour
{
    public GameObject screenUiOrder;
    public Transform orderUiArea;

    private OrderManager _orderManager;
    private List<WorldOrder> _screenOrder = new List<WorldOrder>();

    private void Awake()
    {
        _orderManager = FindObjectOfType<OrderManager>();
    }
    private IEnumerator Start()
    {
        yield return StartCoroutine("GetOrders");
        CreateScreenOrder();
    }
    private void Update()
    {
        CloneWorldOrders();
    }
    private void CloneWorldOrders()
    {
        for (int i = 0; i < _screenOrder.Count; i++)
        {
            _screenOrder[i].CloneOrder(_orderManager.visualOrders[i]);
        }
    }
    private void CreateScreenOrder()
    {
        for (int i = 0; i < _screenOrder.Count; i++)
        {
            GameObject newVisualOrder = Instantiate(screenUiOrder, orderUiArea);
            _screenOrder[i] = newVisualOrder.GetComponent<WorldOrder>();
            _screenOrder[i].followPlayer = false;
        }
    }
    private IEnumerator GetOrders()
    {
        yield return new WaitForSeconds(.5f);
        _screenOrder = CloneOrderList();
    }
    private List<WorldOrder> CloneOrderList()
    {
        var list = new List<WorldOrder>();
        foreach(WorldOrder order in _orderManager.visualOrders)
        {
            list.Add(order);
        }
        return list;
    }
}
