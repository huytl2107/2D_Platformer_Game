using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigAttackState : EnemiesAttackState
{
    public PigAttackState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.EPigState.attack);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        CheckSwitchState();
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if(!enemy.SeePlayer)
        {
            enemy.Rb.velocity = new Vector2(enemy.WalkSpeed*2 * enemy.RaycastDirX, enemy.Rb.velocity.y);
            enemy.StartCoroutine(ChangeToWalkState());
        }
        else
        {
            enemy.Rb.velocity = new Vector2(enemy.WalkSpeed*2 * enemy.RaycastDirX, enemy.Rb.velocity.y);
        }
    }

    public IEnumerator ChangeToWalkState()
    {
        yield return new WaitForSeconds(2f);
        SwitchState(factory.PigWalk());
    }

}
