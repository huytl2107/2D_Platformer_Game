using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadishGotHitState : EnemiesGotHitState
{
    public RadishGotHitState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.ERadishState.gotHit);
        enemy.Rb.bodyType = RigidbodyType2D.Dynamic;
        enemy.StartCoroutine(SwitchToIdleState());
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
    }

    private IEnumerator SwitchToIdleState()
    {
        yield return new WaitForSeconds(1f);
        SwitchState(factory.RadishIdle());
    }
}
