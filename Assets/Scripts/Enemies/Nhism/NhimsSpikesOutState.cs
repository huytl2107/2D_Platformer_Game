using System.Collections;
using UnityEngine;

public class NhimsSpikesOutState : EnemiesIdleState
{
    public NhimsSpikesOutState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.ENhismState.spikesOut);
        enemy.StartCoroutine(SwitchToNonSpikesState());
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
    }

        public IEnumerator SwitchToNonSpikesState()
    {
        yield return new WaitForSeconds(1f);
        SwitchState(factory.NhismNonSpikes());
    }
}
