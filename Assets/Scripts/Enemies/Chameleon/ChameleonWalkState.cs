using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChameleonWalkState : EnemiesWalkState
{
    private Coroutine switchToIdleCoroutine;
    public ChameleonWalkState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.EChameleonState.walk);
        switchToIdleCoroutine = enemy.StartCoroutine(SwitchToIdleState());
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(enemy.SeePlayer)
        {
            //Hủy coroutine trước khi SwitchState
            enemy.StopCoroutine(switchToIdleCoroutine);
            switchToIdleCoroutine = null;
            SwitchState(factory.ChameleonAttack());
        }
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
    }

    public IEnumerator SwitchToIdleState()
    {
        yield return new WaitForSeconds(7f);
        SwitchState(factory.ChameleonIdle());
    }
}
