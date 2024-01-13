using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class NhismNonSpikesState : EnemiesWalkState
{
    public NhismNonSpikesState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.ENhismState.nonSpikes);
        enemy.StartCoroutine(SwitchToSpikeInState());
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
    }

    public IEnumerator SwitchToSpikeInState()
    {
        yield return new WaitForSeconds(3.5f);
        SwitchState(factory.NhismSpikesIn());
    }
}
