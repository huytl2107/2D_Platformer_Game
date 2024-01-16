using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadishFlyingState : EnemiesIdleState
{
    private bool _isFlying = false;
    public RadishFlyingState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Health +=1;
        enemy.Rb.bodyType = RigidbodyType2D.Kinematic;
        enemy.Rb.velocity = new Vector2 (0f,0f);
        enemy.Anim.SetInteger("State", (int)StateEnum.ERadishState.flying);
        enemy.StartCoroutine(Flying());
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(_isFlying)
        {
            enemy.Rb.velocity = new Vector2(0f, 1.5f);
        }
        else
        {
            enemy.Rb.velocity = new Vector2(0f, 0f);
        }
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
    }

    private IEnumerator Flying()
    {
        _isFlying = true;
        yield return new WaitForSeconds(2f);
        _isFlying = false;
    }
}
