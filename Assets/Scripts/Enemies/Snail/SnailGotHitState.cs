using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailGotHitState : EnemiesGotHitState
{
    public SnailGotHitState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        enemy.Health -= 1;
        if (enemy.Health < 0)
        {
            enemy.Anim.SetTrigger("Death");
            enemy.Rb.AddForce(Vector2.up * 4f, ForceMode2D.Impulse);
            enemy.EnemiesDeath();
        }
        else if (enemy.Health < 1)
        {
            enemy.Anim.SetInteger("State", (int)StateEnum.ESnailState.jumpHit);
            enemy.StartCoroutine(SwitchToShellAttackState());
        }
        else
        {
            enemy.Anim.SetInteger("State", (int)StateEnum.ESnailState.jumpHit);
            enemy.Rb.bodyType = RigidbodyType2D.Dynamic;
            EffectPooler.Instant.GetPoolObject("SnailEffect", enemy.transform.position, Quaternion.identity);
            enemy.StartCoroutine(SwitchToShellState());
        }
    }

    public override void UpdateState()
    {
        if (enemy.Health == 0)
        {
            enemy.Rb.velocity = new Vector2(enemy.WalkSpeed * 10f, enemy.Rb.velocity.y);
        }
    }

    private IEnumerator SwitchToShellState()
    {
        yield return new WaitForSeconds(.5f);
        SwitchState(factory.SnailShell());
    }
    private IEnumerator SwitchToShellAttackState()
    {
        yield return new WaitForSeconds(.5f);
        SwitchState(factory.SnailShellAttack());
    }
}
