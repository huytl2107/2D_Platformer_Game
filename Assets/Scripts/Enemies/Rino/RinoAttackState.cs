using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinoAttackState : EnemiesAttackState
{
    public RinoAttackState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.ERinoState.attack);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        enemy.Rb.velocity = new Vector2(enemy.WalkSpeed * 2.5f * enemy.RaycastDirX, enemy.Rb.velocity.y);
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if(enemy.SeeGround)
        {
            SwitchState(factory.RinoHitWall());
        }
    }
}
