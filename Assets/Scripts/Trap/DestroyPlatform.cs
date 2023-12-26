using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    [SerializeField] private float waitToDestroy;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Player")
        {
            Invoke("Destroy", 3f);
        }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}