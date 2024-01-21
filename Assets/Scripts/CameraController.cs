using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float _plusY;

    void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y + _plusY, transform.position.z);
    }
}
