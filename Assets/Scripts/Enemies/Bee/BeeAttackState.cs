using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAttackState : EnemiesAttackState
{
    public BeeAttackState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.EBeeState.attack);
        enemy.StartCoroutine(SwitchToWalkState());
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
    }

    public IEnumerator SwitchToWalkState()
    {
        yield return new WaitForSeconds(.8f);
        SwitchState(factory.BeeWalk());
    }
}
