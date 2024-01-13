using System.Collections;
using UnityEngine;

public class NhimSpikesState : EnemiesWalkState
{
    public NhimSpikesState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.ENhismState.spikes);
        enemy.StartCoroutine(SwitchToSpikeOutState());
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
    }

    public IEnumerator SwitchToSpikeOutState()
    {
        yield return new WaitForSeconds(3.5f);
        SwitchState(factory.NhismSpikeOut());
    }
}
