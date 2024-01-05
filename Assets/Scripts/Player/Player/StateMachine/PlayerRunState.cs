using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Hello from run state");
    }

    public override void OnCollisionEnter2D(PlayerStateManager player)
    {

    }

    public override void UpdateState(PlayerStateManager player)
    {

    }
}
