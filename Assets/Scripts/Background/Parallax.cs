using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Parallax : MonoBehaviour
{
    private CameraController _cam;
    private float _startPosX;
    private float _startPosY;
    private Tilemap _tilemap;
    private float _length;
    [SerializeField] private float _xParalaxEffect;
    [SerializeField] private float _yParalaxEffect;

    void Awake()
    {
        _cam = FindObjectOfType<CameraController>();
        _tilemap = GetComponent<Tilemap>();
        _length = _tilemap.cellSize.x * _tilemap.size.x;
    }

    private void Start()
    {
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
