public class PlayerStateFactory
{
    PlayerStateManager _context;

    public PlayerStateFactory(PlayerStateManager currentContext)
    {
        _context = currentContext;
    }
    public PlayerBaseState Idle()
    {
        return new PlayerIdleState(_context, this);
    }
    public PlayerBaseState Run()
    {
        return new PlayerRunState(_context, this);
    }
    public PlayerBaseState Jump()
    {
        return new PlayerJumpState(_context, this);
    }
    public PlayerBaseState Fall()
    {
        return new PlayerFallState(_context, this);
    }
    public PlayerBaseState DoubleJump()
    {
        return new PlayerDoubleJumpState(_context, this);
    }
    public PlayerBaseState Dash()
    {
        return new PlayerDashState(_context, this);
    }
    public PlayerBaseState WallSlide()
    {
        return new PlayerWallSlideState(_context, this);
    }
    public PlayerBaseState WallJump()
    {
        return new PlayerWallJumpState(_context, this);
    }
    public PlayerBaseState GotHit()
    {
        return new PlayerGotHitState(_context, this);
    }
}
