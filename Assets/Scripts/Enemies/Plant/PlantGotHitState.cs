using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGotHitState : EnemiesGotHitState
{
    public PlantGotHitState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        SoundManager.Instant.PlaySound(GameEnum.ESound.plantGotHit);
    }
}
