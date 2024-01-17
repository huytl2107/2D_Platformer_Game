using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BunnyIdleState : EnemiesIdleState
{
    public BunnyIdleState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    private Coroutine flippingCoroutine;

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.EBunnyState.idle);
        flippingCoroutine = enemy.StartCoroutine(FlipObject());
    }

    public override void UpdateState()
    {
        base.UpdateState();
        enemy.Rb.velocity = new Vector2(0f, enemy.Rb.velocity.y);
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if(enemy.SeePlayer)
        {
            enemy.StopAllCoroutines();
            flippingCoroutine = null;
            SwitchState(factory.BunnyRun());
        }
    }

    private IEnumerator FlipObject()
    {
        yield return new WaitForSeconds(1.5f);
        enemy.FlipXObject();
        enemy.StartCoroutine(FlipObject());
    }
}
