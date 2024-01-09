using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MushroomStateManager : EnemiesStateManager
{
    public MushRoomWalkState MushroomWalk;
    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();
        MushroomWalk = new MushRoomWalkState(this);
    }

    void Start()
    {
        CurrentState = MushroomWalk;
        CurrentState.EnterState();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        CurrentState.UpdateState();
    }

    public override void SwitchState(EnemiesBaseState enemyState)
    {

    }
}
