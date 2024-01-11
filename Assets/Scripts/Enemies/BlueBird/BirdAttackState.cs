using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAttackState : EnemiesAttackState
{
    public BirdAttackState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.Player.transform.position, Time.deltaTime * enemy.WalkSpeed);
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
    }
}
