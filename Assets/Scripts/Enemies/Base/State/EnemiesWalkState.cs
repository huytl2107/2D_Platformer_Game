using UnityEngine;

public class EnemiesWalkState : EnemiesBaseState
{
    public EnemiesWalkState(EnemiesStateManager currentContext) : base(currentContext)
    {
    }

    public override void CheckSwitchState()
    {

    }

    public override void EnterState()
    {
        Debug.Log("Hello from Walk State");
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        enemy.Rb.velocity = new Vector2(enemy.WalkSpeed * enemy.RaycastDirX , enemy.Rb.velocity.y);
    }
}
