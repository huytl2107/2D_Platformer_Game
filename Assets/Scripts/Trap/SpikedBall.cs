using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Timeline;

public class SpikedBall : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _time;
    private float _thisTime;
    private float _distance;
    private float x;

    void Start()
    {
        _distance = Math.Abs(_target.position.x - transform.position.x);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _thisTime += Time.fixedDeltaTime;

        //Tính vị trí của x và y gốc tọa độ là Target
        x = _distance * Mathf.Cos(((2 * Mathf.PI) / _time) * _thisTime + (Mathf.PI / 1));
        float y = -Mathf.Sqrt(_distance * _distance - x * x);

        //xoay góc
        float angle = (x!=0) ? (float)Math.Atan(y / x) *180f/Mathf.PI : 90;
        transform.rotation = Quaternion.Euler(0, 0, (x<0) ? angle : 180 + angle);

        //Trả về gốc tọa độ của game
        x = _target.position.x + x;
        y = _target.position.y + y;
        transform.position = new Vector2(x, y);
    }
}
