using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenRunState : EnemiesWalkState
{
    public ChickenRunState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Rb.gravityScale = 8f;
        enemy.Rb.AddForce(Vector2.up * 15f, ForceMode2D.Impulse);
        enemy.Anim.SetInteger("State", (int)StateEnum.EChickenState.run);
        enemy.FlipXObject();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if(enemy.SeeGround)
        {
            SwitchState(factory.ChickenGotHit());
        }
    }
}
