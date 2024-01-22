using System.Collections;
using System.Collections.Generic;
using Mono.CompilerServices.SymbolWriter;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _damping = 3;

    [Header("Offset and CameraClamping")]
    [SerializeField] private Vector2 _offset;
    private Vector3 _originialOffset;
    [SerializeField] private float _minX = -1000;
    [SerializeField] private float _maxX = 1000;

    void Awake()
    {
        _originialOffset = _offset;
    }

    private int lastX;
    private bool faceLeft;

    void FixedUpdate()
    {
        _offset.y = _originialOffset.y;
        int currentX = Mathf.RoundToInt(_player.position.x);
        if (currentX > lastX) faceLeft = false; else if (currentX < lastX) faceLeft = true;
        lastX = Mathf.RoundToInt(_player.position.x);

        if(Input.GetKey(KeyCode.S))
        {
            _offset.y -=6;
        }

        Vector3 target;
        //Đặt toàn bộ targer.z vè -10 để đảm bảo camera k bị che lấp
        if (_player.transform.position.x < _minX)
        {
            target = new Vector3(_minX, _player.position.y + _offset.y, -10f);
        }
        else if (_player.transform.position.x > _maxX)
        {
            target = new Vector3(_maxX, _player.position.y + _offset.y, -10f);
        }
        else
        {
            if (faceLeft)
            {
                target = new Vector3(_player.position.x - _offset.x, _player.position.y + _offset.y, -10f);
            }
            else
            {
                target = new Vector3(_player.position.x + _offset.x, _player.position.y + _offset.y, -10f);
            }
        }

        Vector3 currentPosition = Vector3.Lerp(transform.position, target, _damping * Time.deltaTime);
        transform.position = currentPosition;
    }
}
