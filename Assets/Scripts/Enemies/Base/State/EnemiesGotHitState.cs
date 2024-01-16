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
        enemy.Health -=1;
        if (enemy.Health < 0)
        {
            enemy.Anim.SetTrigger("Death");
            enemy.Rb.AddForce(Vector2.up * 4f, ForceMode2D.Impulse);
            enemy.EnemiesDeath();
        }
        else
        {
            
        }
    }

    protected IEnumerator SwitchToIdleState()
    {
        yield return new WaitForSeconds(1f);
        SwitchState(factory.RadishIdle());
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        CheckSwitchState();
    }

    public override void CheckSwitchState()
    {

    }

}
