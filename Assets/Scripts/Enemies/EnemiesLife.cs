using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesLife : EnemiesDeath
{
    [SerializeField] public int lives = 2;

    private void Update()
    {
        GotHitEffect();
    }
    private void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.name == "Player" || col.CompareTag("Weapon"))
        {
            DeathorAlive();
        }
    }
    private void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.CompareTag("Trap"))
        {
            DeathorAlive();
        }
    }
    private void DeathorAlive()
    {
        if(lives >0)
        {
            GotHit();
        }
        else
        {
            Death();
        }
    }
    private void GotHit()
    {
        canKill = false;
        Invoke("NowCanKill", 1.5f);
        anim.SetInteger("State", 1);
        rb.AddForce(Vector2.up * 3f, ForceMode2D.Impulse);
        rb.bodyType = RigidbodyType2D.Dynamic;
        lives -=1;  
        Debug.Log("Lives:" + lives);
    }
    private void NowCanKill()
    {
        canKill = true;
    }
}
