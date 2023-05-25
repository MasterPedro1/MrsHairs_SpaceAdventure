using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorldOrder : MonoBehaviour
{
    public TextMeshProUGUI detailsText;
    public Slider timer;
    public bool followPlayer = true;
    private Transform _player;

    private void Awake()
    {
        detailsText = GetComponentInChildren<TextMeshProUGUI>();
        timer = GetComponentInChildren<Slider>();
        _player = Camera.main.transform;
    }
    private void Update()
    {
        if (followPlayer) { RotateToPlayer(); }
    }
    private void RotateToPlayer()
    {
        transform.LookAt(_player.position);
    }
    public void CloneOrder(WorldOrder orderToClone)
    {
        detailsText = orderToClone.detailsText;
        timer = orderToClone.timer;
    }
}
