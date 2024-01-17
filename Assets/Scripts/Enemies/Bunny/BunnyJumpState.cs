using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyJumpState : EnemiesWalkState
{
    public BunnyJumpState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Rb.gravityScale = 9f;
        enemy.Rb.AddForce(Vector2.up * 30f, ForceMode2D.Impulse);
        enemy.Anim.SetInteger("State", (int)StateEnum.EBunnyState.jump);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if(enemy.Rb.velocity.y < .1f)
        {
            SwitchState(factory.BunnyFall());
        }
    }

    public override void ExitState()
    {
        base.ExitState();
        enemy.Rb.gravityScale = 1f;
    }
}
