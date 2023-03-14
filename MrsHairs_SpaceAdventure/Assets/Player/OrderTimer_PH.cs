using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OrderTimer_PH : MonoBehaviour
{
    public float timer;
    public UnityEvent onDeliver;
    IEnumerator CountTime()
    {
        yield return new WaitForEndOfFrame();
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            print("Order Lost");
            StopCoroutine(CountTime());
        }
        StartCoroutine(CountTime());
    }
    // Start is called before the first frame update
    void Start()
    {
        print("A quessadilla to go!");
        StartCoroutine(CountTime());
    }
    public void OrderDelivered()
    {
        print("Order succesful!");
        StopCoroutine(CountTime());
        StopAllCoroutines();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            onDeliver.Invoke();
        }
    }
}
