using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinoHitWallState : EnemiesIdleState
{
    public RinoHitWallState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.ERinoState.hitWall);
        enemy.StartCoroutine(SwitchToIdleState());
    }

    public override void UpdateState() 
    {
        enemy.Rb.velocity = new Vector2(enemy.RaycastDirX * -2, enemy.Rb.velocity.y);    
    }

    private IEnumerator SwitchToIdleState()
    {
        yield return new WaitForSeconds(1f);
        enemy.FlipXObject();
        SwitchState(factory.RinoIdle());
    }
}
