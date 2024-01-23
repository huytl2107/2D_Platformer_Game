using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailShellAttackState : EnemiesAttackState
{
    public SnailShellAttackState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.ESnailState.shell);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        enemy.Rb.velocity = new Vector2(enemy.WalkSpeed*10f, enemy.Rb.velocity.y);
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if(enemy.SeeGround)
        {
            SwitchState(factory.SnailGotHit());
        }
    }
}
