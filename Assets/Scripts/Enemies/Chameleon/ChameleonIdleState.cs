using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChameleonIdleState : EnemiesIdleState
{
    private Coroutine switchToWalkCoroutine;
    public ChameleonIdleState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.EChameleonState.idle);
        switchToWalkCoroutine = enemy.StartCoroutine(SwitchToWalkState());
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if(enemy.SeePlayer)
        {
            //Hủy coroutine trước khi SwitchState
            enemy.StopCoroutine(switchToWalkCoroutine);
            switchToWalkCoroutine = null;
            SwitchState(factory.ChameleonAttack());
        }
    }

    public IEnumerator SwitchToWalkState()
    {
        yield return new WaitForSeconds(3f);
        SwitchState(factory.ChameleonWalk());
    }
}
