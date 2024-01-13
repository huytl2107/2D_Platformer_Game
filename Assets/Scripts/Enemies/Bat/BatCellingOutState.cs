using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCellingOutState : EnemiesIdleState
{
    public BatCellingOutState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.EBatState.cellingOut);
        enemy.StartCoroutine(SwitchToAttackState());
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
    }

    public IEnumerator SwitchToAttackState()
    {
        yield return new WaitForSeconds(1f);
        SwitchState(factory.BatAttack());
    }
}
