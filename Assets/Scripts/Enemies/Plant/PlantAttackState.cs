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
        enemy.StartCoroutine(SwitchToIdleState());
    }

    public override void UpdateState()
    {
        base.UpdateState();
        CheckSwitchState();
    }
    public override void CheckSwitchState()
    {

    }

    private IEnumerator SwitchToIdleState()
    {
        yield return new WaitForSeconds(1f);
        SwitchState(factory.PlantIdle());
    }

}
