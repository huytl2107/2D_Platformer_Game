using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatReturnState : EnemiesAttackState
{
    public BatReturnState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        enemy.LookAtFirstPosition();
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.FirstPosition, Time.deltaTime * enemy.WalkSpeed);
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if(Vector2.Distance(enemy.transform.position, enemy.FirstPosition) < .1f)
        {
            SwitchState(factory.BatCellingIn());
        }
    }
}
