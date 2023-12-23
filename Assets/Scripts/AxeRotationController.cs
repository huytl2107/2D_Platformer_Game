using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeRotationController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    void Update()
    {
        transform.Rotate(0,0,-36* speed * Time.deltaTime);
    }
}
