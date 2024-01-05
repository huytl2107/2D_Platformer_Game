using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState _currentState;
    public PlayerIdleState IdleState = new PlayerIdleState();
    public PlayerRunState RunState = new PlayerRunState();
    // Start is called before the first frame update
    void Start()
    {
        _currentState = IdleState;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);
    }
    public void SwitchState(PlayerBaseState state)
    {
        _currentState = state;
        state.EnterState(this);
    }
}
