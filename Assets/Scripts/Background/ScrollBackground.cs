using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float _plusY;
    [SerializeField] private float _scrollSpeed;
    [SerializeField] private float _length = 40f;
    private float _distance;

    void FixedUpdate()
    {
        _distance += _scrollSpeed * Time.fixedDeltaTime;
        if(_distance >=_length || _distance <= -_length) _distance = 0;
        transform.position = new Vector3(player.position.x + _distance, player.position.y + _plusY, transform.position.z);
    }
}
