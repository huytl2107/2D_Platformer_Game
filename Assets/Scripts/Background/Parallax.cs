using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{
    private CameraController _cam;
    private float _startPosX;
    private float _startPosY;
    [SerializeField] private float _length = 40f;
    [SerializeField] private float _xParalaxEffect;
    [SerializeField] private float _yParalaxEffect;

    void Awake()
    {
        _cam = FindObjectOfType<CameraController>();
    }

    private void Start()
    {
        _startPosX = transform.position.x;
        _startPosY = transform.position.y;
    }

    private void FixedUpdate()
    {
        float temp = _cam.transform.position.x * (1 - _xParalaxEffect);
        float distX = _cam.transform.position.x * _xParalaxEffect;
        float distY = _cam.transform.position.y * _yParalaxEffect;

        transform.position = new Vector2(_startPosX + distX, (_yParalaxEffect != 0) ? _startPosY + distY : _cam.transform.position.y);

        if(temp > _startPosX + _length) _startPosX += _length;
        else if(temp < _startPosX - _length) _startPosX -= _length;
    }
}
