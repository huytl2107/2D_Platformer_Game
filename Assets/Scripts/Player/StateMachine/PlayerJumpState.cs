using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    private float _time;
    public PlayerJumpState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }
    //Jump force = 30f;
    //OriginialGravity = 9f;
    public override void EnterState()
    {
        _time = 0f;
        player.IsDoubleJump = false;
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.jump);
        //player.Rb.velocity = new Vector2(player.Rb.velocity.x, player.JumpForce);
    }

    public override void UpdateState()
    {
        _time += Time.deltaTime;
        CheckSwitchState();
        PlayerStateManager.UpdateObjectDirX(player);
    }

    public override void FixedUpdateState()
    {
        player.CanMove();
    }

    public override void CheckSwitchState()
    {
        if (InputManager.Instant.Dash() && player.CanDash)
        {
            SwitchState(factory.Dash());
        }
        else if (player.IsSeeingGround)
        {
            SwitchState(factory.WallSlide());
        }
        else
        {
            if (player.Rb.velocity.y < .1f)
            {
                SwitchState(factory.Fall());
            }
            else if (InputManager.Instant.Jump() && _time > .25f) //Delay ra tí để k bị dính button nhảy 2 lần tren mobile
            {
                player.IsDoubleJump = true;
                SwitchState(factory.DoubleJump());
            }
        }
    }

    public override void ExitState()
    {

    }

}
