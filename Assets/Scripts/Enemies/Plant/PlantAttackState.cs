using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlantAttackState : EnemiesAttackState
{
    public PlantAttackState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.EPlantState.attack);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        CheckSwitchState();
    }
    public override void CheckSwitchState()
    {
        if(!enemy.SeePlayer)
        {
            SwitchState(factory.PlantIdle());
        }
    }
}
