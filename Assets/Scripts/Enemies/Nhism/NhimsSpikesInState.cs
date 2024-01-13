using System.Collections;
using UnityEngine;

public class NhimsSpikesInState : EnemiesIdleState
{
    public NhimsSpikesInState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.ENhismState.spikesIn);
        enemy.StartCoroutine(SwitchToSpikeState());
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
    }

    public IEnumerator SwitchToSpikeState()
    {
        yield return new WaitForSeconds(1f);
        SwitchState(factory.NhismSpikes());
    }
}
