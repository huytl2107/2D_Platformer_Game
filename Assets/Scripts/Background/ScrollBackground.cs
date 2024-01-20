using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class ScrollBackground : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed;
    private Tilemap _tilemap;
    private float _temp = 0;
    private float _backgroundWidth;

    void Awake()
    {
        _tilemap = GetComponent<Tilemap>();
    }
    void Start()
    {
        // Tính chiều rộng của background.
        _backgroundWidth = _tilemap.cellSize.x * _tilemap.size.x;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        _temp += _scrollSpeed*Time.fixedDeltaTime;
        transform.position = new Vector2(transform.position.x + _scrollSpeed * Time.fixedDeltaTime, transform.position.y);
        
        if (_temp < -_backgroundWidth)
        {
            _temp = 0;
            float newX = _backgroundWidth - _scrollSpeed * Time.deltaTime;
            transform.position = new Vector2(newX, transform.position.y);
        }
    
    }
}
