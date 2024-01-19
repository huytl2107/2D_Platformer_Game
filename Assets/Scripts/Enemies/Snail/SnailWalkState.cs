using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnailWalkState : EnemiesWalkState
{
    public SnailWalkState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.ESnailState.walk);
    }

    public override void UpdateState()
    {
        float normalizedAngle = Mathf.Repeat(enemy.transform.eulerAngles.z, 360f);
        if (Mathf.Approximately(normalizedAngle, 0f))
        {
            //right;
            enemy.Rb.velocity = new Vector2(enemy.WalkSpeed, 0f);
        }
        else if (Mathf.Approximately(normalizedAngle, 90f))
        {
            //up;
            enemy.Rb.velocity = new Vector2(0f, enemy.WalkSpeed);
        }
        else if (Mathf.Approximately(normalizedAngle, 180f))
        {
            //left;
            enemy.Rb.velocity = new Vector2(-enemy.WalkSpeed, 0f);
        }
        else if (Mathf.Approximately(normalizedAngle, 270f))
        {
            //down;
            enemy.Rb.velocity = new Vector2(0f, -enemy.WalkSpeed);
        }
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
    }
}
