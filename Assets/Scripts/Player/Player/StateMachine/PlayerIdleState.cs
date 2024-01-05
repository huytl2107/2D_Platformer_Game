using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Hello from current state");
    }

    public override void OnCollisionEnter2D(PlayerStateManager player)
    {

    }

    public override void UpdateState(PlayerStateManager player)
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        if(dirX != 0)
        {
            player.SwitchState(player.RunState);
        }
    }
}
