using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullLife : EnemiesLife
{
    protected override void GotHit()
    {
        if (canAttack)
        {
            canAttack = false;
            Invoke("NowCanAttack", 1.1f);
            lives -= 1;
            if (lives > 4)
            {
                Debug.Log("GotHit1 Lives: " + lives);
                anim.SetInteger("State", 1);
            }
            else if (lives == 4)
            {
                anim.SetInteger("State", 2);
            }
            else
            {
                Debug.Log("GotHit2 Lives: " + lives);
                anim.SetInteger("State", 4);
            }
            rb.AddForce(Vector2.up * 3f, ForceMode2D.Impulse);
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

}

