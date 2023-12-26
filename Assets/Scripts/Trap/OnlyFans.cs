using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyFans : MonoBehaviour
{
    [SerializeField] private float fanForce = 10f;
    private void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.name == "Player")
        {
            Rigidbody2D playerRB = col.GetComponent<Rigidbody2D>();
            playerRB.AddForce(Vector2.up * fanForce, ForceMode2D.Impulse);
        }
    }
}
