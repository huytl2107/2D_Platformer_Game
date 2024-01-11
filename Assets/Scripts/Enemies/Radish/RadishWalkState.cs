using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadishWalkState : EnemiesWalkState
{
    public RadishWalkState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.ERadishState.run);
        enemy.StartCoroutine(SwitchToFlyingState());
    }

    public override void UpdateState()
    {
        base.UpdateState();
        enemy.Rb.velocity = new Vector2(enemy.WalkSpeed * 1.5f * enemy.RaycastDirX, enemy.Rb.velocity.y);
    }
    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
    }
    
    public IEnumerator SwitchToFlyingState()
    {
        yield return new WaitForSeconds(2f);
        SwitchState(factory.RadishFly());
    }
}
