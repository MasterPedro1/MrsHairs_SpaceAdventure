using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    GameObject _player;

    private void Start()
    {
        //_player = GameObject.FindGameObjectWithTag("Player");
        _player = Camera.main.gameObject;
    }

    private void Update()
    {
        transform.LookAt(_player.transform.position, Vector3.up);
    }
}
