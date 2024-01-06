using UnityEngine;

public abstract class PlayerBaseState
{
    [SerializeField] protected float Speed;

    public abstract void EnterState(PlayerStateManager player);
    public abstract void UpdateState(PlayerStateManager player);
    public abstract void OnCollisionEnter2D(PlayerStateManager player);
}
