using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlantIdleState : EnemiesIdleState
{
    private bool _canShoot = false;
    public PlantIdleState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.EPlantState.idle);
        enemy.StartCoroutine(CoolDown());
    }

    public override void UpdateState()
    {
        base.UpdateState();
        CheckSwitchState();
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if(enemy.SeePlayer && _canShoot)
        {
            SwitchState(factory.PlantAttack());
        }
    }

    public IEnumerator CoolDown()
    {
        _canShoot = false;
        yield return new WaitForSeconds(1f);
        _canShoot = true;
    }
}
