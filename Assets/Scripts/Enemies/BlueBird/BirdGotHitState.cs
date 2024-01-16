using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGotHitState : EnemiesGotHitState
{
    public BirdGotHitState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }
}
