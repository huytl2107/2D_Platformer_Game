using UnityEngine;

public abstract class PlayerBaseState
{
    protected PlayerStateManager player;
    protected PlayerStateFactory factory;

    public PlayerBaseState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory)
    {
        player = currentContext;
        factory = playerStateFactory;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchState();
    //public abstract void InitializeSubState();
    //protected void SetSuperState();
    //protected void SetSubState();
    protected void SwitchState(PlayerBaseState newState)
    {
        ExitState();
        newState.EnterState();
        player.CurrentState = newState;
    }
}
