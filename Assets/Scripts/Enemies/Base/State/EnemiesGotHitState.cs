using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesGotHitState : EnemiesBaseState
{
    public EnemiesGotHitState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }
    public override void EnterState()
    {
        SoundManager.Instant.PlaySound(GameEnum.ESound.enemyGotHit);
        enemy.Health -=1;
        if (enemy.Health < 0)
        {
            enemy.Col.isTrigger = true;
            enemy.Anim.SetTrigger("Death");
            enemy.Rb.gravityScale = 10f;
            enemy.Rb.AddForce(Vector2.up * 20f, ForceMode2D.Impulse);
            enemy.EnemiesDeath();
        }
        else
        {
            
        }
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        CheckSwitchState();
        enemy.Rb.velocity = new Vector2(enemy.WalkSpeed * enemy.RaycastDirX , enemy.Rb.velocity.y); 
    }

    public override void CheckSwitchState()
    {

    }

}
