using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeWalkState : EnemiesWalkState
{
    public BeeWalkState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.EBeeState.idle);
    }

    public override void UpdateState()
    {
        CheckSwitchState();
        Vector2 topOfPlayer = new Vector2(enemy.Player.transform.position.x, enemy.Player.transform.position.y + 3.5f);
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, topOfPlayer, Time.deltaTime * enemy.WalkSpeed);
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if (Mathf.Abs(enemy.transform.position.x - enemy.Player.transform.position.x) < .2f)
        {
            SwitchState(factory.BeeAttack());
        }
    }
}
