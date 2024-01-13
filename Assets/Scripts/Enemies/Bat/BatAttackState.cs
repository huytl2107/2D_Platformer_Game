using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAttackState : EnemiesAttackState
{
    public BatAttackState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.EBatState.attack);
        enemy.StartCoroutine(SwitchToReturnState());
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        enemy.LookAtPlayer();
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.Player.transform.position, Time.deltaTime * enemy.WalkSpeed);
    }

    public IEnumerator SwitchToReturnState()
    {
        yield return new WaitForSeconds(4f);
        SwitchState(factory.BatReturn());
    }
}
