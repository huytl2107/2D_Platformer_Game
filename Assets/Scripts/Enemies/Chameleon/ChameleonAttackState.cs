using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChameleonAttackState : EnemiesAttackState
{
    public ChameleonAttackState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Rb.velocity = new Vector2(0f, enemy.Rb.velocity.y);
        enemy.Anim.SetInteger("State", (int)StateEnum.EChameleonState.attack);
        enemy.StartCoroutine(SwithToIdleState());
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
    }

    public IEnumerator SwithToIdleState()
    {
        yield return new WaitForSeconds(1f);
        SwitchState(factory.ChameleonIdle());
    }
}
