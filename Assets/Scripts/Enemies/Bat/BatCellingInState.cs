using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCellingInState : EnemiesIdleState
{
    public BatCellingInState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.EBatState.cellingIn);
        enemy.StartCoroutine(SwitchToIdleState());
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
    }

    public IEnumerator SwitchToIdleState()
    {
        yield return new WaitForSeconds(1f);
        SwitchState(factory.BatIdle());
    }
}
