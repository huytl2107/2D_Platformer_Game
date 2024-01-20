using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private CameraController _cam;
    private float _startPosX;
    private float _startPosY;
    [SerializeField] private float _xParalaxEffect;
    [SerializeField] private float _yParalaxEffect;
    private void Start()
    {
        _cam = FindObjectOfType<CameraController>();
        _startPosX = transform.position.x;
        _startPosY = transform.position.y;
    }

    private void FixedUpdate()
    {
        float distX = _cam.transform.position.x * _xParalaxEffect;
        float distY = _cam.transform.position.y * _yParalaxEffect;
        transform.position = new Vector2(_startPosX + distX, _startPosY + distY);
    }
}
