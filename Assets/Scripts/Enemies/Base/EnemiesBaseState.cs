using UnityEngine;

public abstract class EnemiesBaseState
{
    protected EnemiesStateManager enemy;
    protected EnemiesStateFactory factory;

    public EnemiesBaseState(EnemiesStateManager currentContext, EnemiesStateFactory currentState)
    {
        enemy = currentContext;
        factory = currentState;
    }
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void CheckSwitchState();
    public abstract void ExitState();
    public void SwitchState(EnemiesBaseState newState)
    {
        ExitState();
        newState.EnterState();
        enemy.CurrentState = newState;
    }
}
