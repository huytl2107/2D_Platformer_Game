using UnityEngine;

public class EnemiesWalkState : EnemiesBaseState
{
    public EnemiesWalkState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void CheckSwitchState()
    {

    }

    public override void EnterState()
    {
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        CheckSwitchState();
        enemy.Rb.velocity = new Vector2(enemy.WalkSpeed * enemy.RaycastDirX , enemy.Rb.velocity.y);
    }
}
