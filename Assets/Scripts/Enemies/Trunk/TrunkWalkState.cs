using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkWalkState : EnemiesWalkState
{
    //Bug chuyển từ Attack về Idle không chuyển Anim
    //Chưa tìm ra nguyên nhân => Chống cháy
    private bool _switched = false;
    public TrunkWalkState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.ETrunkState.walk);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        //Chuyển state một lần nữa trong update để về Anim Walk
        if(!_switched) enemy.StartCoroutine(SetAnim());
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if (enemy.SeePlayer)
        {
            //Cần clean chõ này
            _switched = false;
            SwitchState(factory.TrunkAttack());
        }
    }

    private IEnumerator SetAnim()
    {
        _switched = true;
        yield return new WaitForSeconds(.3f);
        enemy.Anim.SetInteger("State", (int)StateEnum.ETrunkState.walk);
    }
}
