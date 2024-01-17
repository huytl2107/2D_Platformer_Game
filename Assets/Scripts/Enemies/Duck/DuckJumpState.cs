using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DuckJumpState : EnemiesWalkState
{
    public DuckJumpState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Rb.gravityScale = 9f;
        enemy.Rb.AddForce(Vector2.up * 35f, ForceMode2D.Impulse);
        enemy.Anim.SetInteger("State", (int)StateEnum.EDuckState.jump);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if (enemy.Rb.velocity.y < .1f)
        {
            SwitchState(factory.DuckFall());
        }
    }

    public override void ExitState()
    {
        enemy.Rb.gravityScale = 1f;
        base.ExitState();
    }
}
