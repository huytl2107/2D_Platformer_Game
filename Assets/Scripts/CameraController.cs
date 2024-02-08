using System.Collections;
using System.Collections.Generic;
using Mono.CompilerServices.SymbolWriter;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    private Transform _player;
    [SerializeField] private float _damping = 3;

    [Header("Offset and CameraClamping")]
    [SerializeField] private Vector2 _offset;
    private Vector3 _originialOffset;
    [SerializeField] private float _minX = -1000;
    [SerializeField] private float _maxX = 1000;

    private float _camPosY;
    public override void Awake()
    {   
        base.Awake();
        _originialOffset = _offset;
        _player = GameObject.FindObjectOfType<PlayerStateManager>().transform;
    }

    private int lastX;
    private bool faceLeft;

    public Transform Player { get => _player; set => _player = value; }

    void FixedUpdate()
    {
        _offset.y = _originialOffset.y;
        int currentX = Mathf.RoundToInt(Player.position.x);
        if (currentX > lastX) faceLeft = false; else if (currentX < lastX) faceLeft = true;
        lastX = Mathf.RoundToInt(Player.position.x);

        if (InputManager.Instant.Down())
        {
            _offset.y -= 6;
        }

        _camPosY = Player.position.y + _offset.y;
        Vector3 target;
        //Đặt toàn bộ targer.z vè -10 để đảm bảo camera k bị che lấp
        if (Player.transform.position.x < _minX)
        {
            target = new Vector3(_minX, _camPosY, -10f);
        }
        else if (Player.transform.position.x > _maxX)
        {
            target = new Vector3(_maxX, _camPosY, -10f);
        }
        else
        {
            if (faceLeft)
            {
                target = new Vector3(Player.position.x - _offset.x, _camPosY, -10f);
            }
            else
            {
                target = new Vector3(Player.position.x + _offset.x, _camPosY, -10f);
            }
        }

        Vector3 currentPosition = Vector3.Lerp(transform.position, target, _damping * Time.deltaTime);
        transform.position = currentPosition;
    }

}
