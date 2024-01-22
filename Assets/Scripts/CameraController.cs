using System.Collections;
using System.Collections.Generic;
using Mono.CompilerServices.SymbolWriter;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform player;
    [SerializeField] private float _offSightXLeft;
    [SerializeField] private float _offSightXRight;

    void FixedUpdate()
    {
        if (player.transform.position.x < _offSightXLeft)
        {
            transform.position = new Vector3(_offSightXLeft, player.position.y + _offset.y, transform.position.z + _offset.z);
        }
        else if (player.transform.position.x > _offSightXRight)
        {
            transform.position = new Vector3(_offSightXRight, player.position.y + _offset.y, transform.position.z + _offset.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x + _offset.x, player.position.y + _offset.y, transform.position.z + _offset.z);
        }
    }
}
