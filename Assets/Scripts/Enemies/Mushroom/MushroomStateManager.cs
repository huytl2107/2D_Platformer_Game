using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MushroomStateManager : EnemiesStateManager
{
    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        CurrentState = State.MushroomWalk();
        CurrentState.EnterState();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        HandleGroundDetection();
        CurrentState.UpdateState();
    }
    
    public override void GotHit()
    {
        CurrentState = State.MushRoomGotHit();
        CurrentState.EnterState();
    }
}
