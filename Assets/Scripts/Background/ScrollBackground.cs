using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _plusY;
    [SerializeField] private float _scrollSpeed;
    [SerializeField] private float _length = 40f;
    private float _distance;
    Vector3 _originialPosition;

    private void Start()
    {
        _originialPosition = transform.position;
    }

    void FixedUpdate()
    {
        _distance += _scrollSpeed * Time.fixedDeltaTime;
        if(_distance >=_length || _distance <= -_length) _distance = 0;
        if(_player == null)
        {
            transform.position = new Vector3(_originialPosition.x + _distance, _originialPosition.y + _plusY, _originialPosition.z);
            return;
        }
        transform.position = new Vector3(_player.position.x + _distance, _player.position.y + _plusY, transform.position.z);
    }
}
