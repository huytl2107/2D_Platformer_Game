using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Hello from Run State");
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.run);
    }

    public override void UpdateState()
    {
        CheckSwitchState();
        PlayerStateManager.UpdateObjectDirX(player);
    }

    public override void CheckSwitchState()
    {
        player.DirX = Input.GetAxisRaw("Horizontal");
        if (player.IsGrounded())
        {
            if (Input.GetButtonDown("Jump"))
            {
                SwitchState(factory.Jump());
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) && player.CanDash)
            {
                SwitchState(factory.Dash());
            }
            else if (player.DirX == 0)
            {
                SwitchState(factory.Idle());
            }
            else
            {
                player.Rb.velocity = new Vector2(player.DirX * player.Speed, player.Rb.velocity.y);
            }
        }
        else if (player.Rb.velocity.y < .1f)
        {
            SwitchState(factory.Fall());
        }
    }

    public override void ExitState()
    {

    }

    public override void InitializeSubState()
    {

    }
}
