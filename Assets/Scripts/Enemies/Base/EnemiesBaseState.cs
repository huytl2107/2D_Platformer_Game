using UnityEngine;

public abstract class EnemiesBaseState
{
    protected EnemiesStateManager enemy;

    public EnemiesBaseState(EnemiesStateManager currentContext)
    {
        enemy = currentContext;
    }
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void CheckSwitchState();
    public abstract void ExitState();
}
