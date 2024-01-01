using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesLife : EnemiesDeath
{
    [SerializeField] public int lives = 2;

    protected void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player" || col.CompareTag("Weapon"))
        {
            DeathorAlive();
        }
    }
    protected void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Trap"))
        {
            DeathorAlive();
        }
    }
    protected void DeathorAlive()
    {
        if (lives > 0)
        {
            GotHit();
        }
        else
        {
            Death();
        }
    }
    protected virtual void GotHit()
    {
        if (canAttack)
        {
            gotHit = true;
            canAttack = false;
            Invoke("NowCanAttack", 1.1f);
            anim.SetInteger("State", 1);
            rb.AddForce(Vector2.up * 3f, ForceMode2D.Impulse);
            rb.bodyType = RigidbodyType2D.Dynamic;
            lives -= 1;
            Debug.Log("Lives:" + lives);
        }
    }
    protected void NowCanAttack()
    {
        gotHit = false;
        canAttack = true;
    }
}
