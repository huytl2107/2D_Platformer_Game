using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlantIdleState : EnemiesIdleState
{
    public PlantIdleState(EnemiesStateManager currentContext) : base(currentContext)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.EPlantState.idle);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        CheckSwitchState();
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if(enemy.SeePlayer)
        {
            enemy.SwitchState(enemy.PlantAttack);
        }
    }
}
